using Newtonsoft.Json;
using Promoter.DataService.Managers;
using Promoter.DataService.Enums;
using Promoter.DataService.Models.Services;
using Promoter.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Models.Domains
{
    public class Validator : BaseDomain
    {
        #region Constructor
        public Validator() : base()
        {
        }

        public Validator(IUnitOfWork uow) : base(uow)
        {
        }

        public Validator(PromoterEntities context) : base(context)
        {
        }
        #endregion

        public ValidationResult Promotion(PromotionViewModel promotion)
        {
            var notValidFields = new List<NotValidField>();

            #region Check valid input
            if (string.IsNullOrWhiteSpace(promotion.PromotionCode))
                notValidFields.Add(NotValidField.From(MessageCode.Validation_BlankNotAllowed, AppObject.PromotionCode));
            if (string.IsNullOrWhiteSpace(promotion.PromotionName))
                notValidFields.Add(NotValidField.From(MessageCode.Validation_BlankNotAllowed, AppObject.PromotionName));
            #endregion

            #region Check valid business
            //validate BrandId
            #endregion

            if (notValidFields.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValidFields);
        }

        public ValidationResult PromotionDetail(PromotionDetailViewModel detail)
        {
            var notValidFields = new List<NotValidField>();

            #region Check valid input
            if (string.IsNullOrWhiteSpace(detail.DetailCode))
                notValidFields.Add(NotValidField.From(MessageCode.Validation_BlankNotAllowed, AppObject.PromotionCode));
            if (detail.ApplyQuantity.HasValue)
                if (detail.ApplyQuantity <= 0)
                    notValidFields.Add(NotValidField.From(MessageCode.Validation_MustGreatherThanZero,
                        AppObject.PromotionDetail, AppObject.ApplyQuantity));
                else detail.AppliedQuantity = 0;
            if (detail.HasVoucher)
                if (detail.VoucherQuantity == null || detail.VoucherQuantity <= 0)
                    notValidFields.Add(NotValidField.From(MessageCode.Validation_MustGreatherThanZero,
                        AppObject.PromotionDetail, AppObject.VoucherQuantity));
                else detail.VoucherUsedQuantity = 0;
            else
            {
                detail.VoucherQuantity = null;
                detail.VoucherUsedQuantity = null;
            }
            detail.AwardCashback = false;
            detail.AwardDiscount = false;
            detail.AwardGift = false;
            if ((detail.AutoGenLength == null && string.IsNullOrWhiteSpace(detail.Pattern)) ||
                (detail.AutoGenLength != null && !string.IsNullOrWhiteSpace(detail.Pattern)))
                notValidFields.Add(NotValidField.From(MessageCode.Validation_MustBeChoosen,
                    new string[] { " -> ", ", " }, AppObject.PromotionDetail, AppObject.VoucherCodeLength, AppObject.VoucherCodePattern));
            else
            {
                var valid = false;
                if (detail.AutoGenLength <= 0)
                    notValidFields.Add(NotValidField.From(MessageCode.Validation_MustGreatherThanZero, AppObject.VoucherCodeLength));
                else if (string.IsNullOrWhiteSpace(detail.Pattern))
                    notValidFields.Add(NotValidField.From(MessageCode.Validation_BlankNotAllowed, AppObject.VoucherCodePattern));
                else valid = true;
                if (valid)
                {
                    if (string.IsNullOrEmpty(detail.Postfix))
                        detail.Postfix = null;
                    if (string.IsNullOrEmpty(detail.Prefix))
                        detail.Prefix = null;
                }
            }


            #endregion

            #region Check valid business
            //check PromotionPartnerId
            //check PromotionId
            #endregion

            if (notValidFields.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValidFields);
        }

        #region Constraint
        public ValidationResult PromotionConstraint(PromotionConstraintViewModel constraint)
        {
            var notValidFields = new List<NotValidField>();
            #region Check valid input
            var time = PC_TimeConstraint(constraint);
            var order = PC_OrderConstraint(constraint);
            var payment = PC_PaymentConstraint(constraint);
            var store = PC_StoreConstraint(constraint);
            var membership = PC_MembershipConstraint(constraint);
            var saleMode = PC_SaleModeConstraint(constraint);
            var collection = PC_CollectionConstraint(constraint);

            if (!time.IsValid)
                notValidFields.AddRange(time.NotValidFields);
            if (!order.IsValid)
                notValidFields.AddRange(order.NotValidFields);
            if (!payment.IsValid)
                notValidFields.AddRange(payment.NotValidFields);
            if (!store.IsValid)
                notValidFields.AddRange(store.NotValidFields);
            if (!membership.IsValid)
                notValidFields.AddRange(membership.NotValidFields);
            if (!saleMode.IsValid)
                notValidFields.AddRange(saleMode.NotValidFields);
            if (!collection.IsValid)
                notValidFields.AddRange(collection.NotValidFields);
            #endregion

            #region Check valid business
            #endregion

            if (notValidFields.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValidFields);
        }

        public ValidationResult PC_TimeConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasTimeContraint)
            {
                var filter = constraint.PC_DateTimeFilterVM;
                var result = PC_DateTimeFilter(filter);
                if (!result.IsValid)
                    notValid.AddRange(result.NotValidFields);
                if (constraint.PromotionBeginDate > constraint.PromotionEndDate)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.TimeConstraint, AppObject.BeginEndDate));
            }
            else
            {
                constraint.PC_DateTimeFilterVM = null;
                constraint.PromotionBeginDate = null;
                constraint.PromotionEndDate = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_DateTimeFilter(IEnumerable<PC_DateTimeFilterViewModel> dtFilters)
        {
            var notValid = new List<NotValidField>();
            var conflict = dtFilters.Any(f => f.DayOfWeek == (int)DoW.All) && dtFilters.Count() > 1;
            if (conflict)
                notValid.Add(NotValidField.From(MessageCode.Validation_NotValid,
                    AppObject.TimeConstraint, AppObject.DayOfWeek));
            else
            {
                if (dtFilters.Any(f => f.BeginDate > f.EndDate))
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.TimeConstraint, AppObject.BeginEndDate));
                if (dtFilters.Any(f => f.BeginHour > f.EndHour))
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.TimeConstraint, AppObject.BeginEndTime));
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_OrderConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();
            if (constraint.HasOrderConstraint)
            {
                if (constraint.MinTotalProducts > constraint.MaxTotalProducts || constraint.MinTotalProducts <= 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.OrderConstraint, AppObject.MinMaxProducts));
                if (constraint.MinTotalAmount > constraint.MaxTotalAmount || constraint.MinTotalAmount <= 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.OrderConstraint, AppObject.MinMaxOrderAmount));
                if (constraint.MinPersonCount > constraint.MaxPersonCount || constraint.MinPersonCount <= 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.OrderConstraint, AppObject.MinMaxPersonCount));
                if (constraint.MinAge > constraint.MaxAge || constraint.MinAge <= 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                        AppObject.OrderConstraint, AppObject.MinMaxAge));
                if (constraint.PC_ProductFilterVM != null)
                {
                    var product = PC_ProductFilter(constraint.PC_ProductFilterVM);
                    if (!product.IsValid)
                        notValid.AddRange(product.NotValidFields);
                }
            }
            else
            {
                constraint.FixProductFilter = null;
                constraint.MinTotalAmount = null;
                constraint.MaxTotalAmount = null;
                constraint.MinTotalProducts = null;
                constraint.MaxTotalProducts = null;
                constraint.MinPersonCount = null;
                constraint.MaxPersonCount = null;
                constraint.MinAge = null;
                constraint.MaxAge = null;
                constraint.Gender = null;
                constraint.PC_ProductFilterVM = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_ProductFilter(IEnumerable<PC_ProductFilterViewModel> pFilters)
        {
            var notValid = new List<NotValidField>();

            //var anyNotValid = pFilters.Any(p => p.ProductId == null && p.ProductMenuId == null && p.ProductCategoryId == null);
            //if (anyNotValid)
            //    notValid.Add(NotValidField.From(MessageCode.Validation_MustBeChoosen,
            //        new string[] { " -> ", ",", "," },
            //        AppObject.ProductFilter, AppObject.Product, AppObject.ProductMenu, AppObject.ProductCategory));
            //else
            //{
            var anyNotValid = pFilters.Any(p => p.MinBuyQuantity > p.MaxBuyQuantity || p.MinBuyQuantity <= 0);
            if (anyNotValid)
                notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue,
                    AppObject.ProductFilter, AppObject.MinMaxQuantity));
            //}
            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_PaymentConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasPaymentConstraint)
            {
                //if (constraint.PaymentType == null && constraint.PaymentPartnerCode == null)
                //    notValid.Add(NotValidField.From(MessageCode.Validation_MustBeChoosen,
                //        new string[] { " -> ", "," }, AppObject.PaymentConstraint, AppObject.PaymentType, AppObject.PaymentPartner));
                //else
                //{
                if (constraint.PaymentType.HasValue && !constraint.PaymentType.Value.IsInPaymentTypeEnum())
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValid, AppObject.PaymentConstraint, AppObject.PaymentType));
                //check valid PaymentPartnerCode
                //}
            }
            else
            {
                constraint.PaymentPartnerCode = null;
                constraint.PaymentType = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_StoreConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasStoreConstraint)
            {
                //temp
            }
            else
            {
                constraint.PC_StoreFilterVM = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_MembershipConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasMembershipConstraint)
            {
                if (constraint.MembershipMinLevel > constraint.MembershipMaxLevel || constraint.MembershipMinLevel < 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue, AppObject.MembershipConstraint, AppObject.MinMaxMembershipLevel));
                if (constraint.MinPoint > constraint.MaxPoint || constraint.MinPoint < 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_NotValidMinMaxValue, AppObject.MembershipConstraint, AppObject.MinMaxPoint));
                if (constraint.MinJoinDate < 0)
                    notValid.Add(NotValidField.From(MessageCode.Validation_MustNotBeNegative, AppObject.MembershipConstraint, AppObject.MinJoinDate));
            }
            else
            {
                constraint.MembershipCode = null;
                constraint.MembershipCodePattern = null;
                constraint.MembershipMaxLevel = null;
                constraint.MembershipMinLevel = null;
                constraint.MembershipTypeCode = null;
                constraint.MinPoint = null;
                constraint.MaxPoint = null;
                constraint.MinJoinDate = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_SaleModeConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasSaleModeConstraint)
            {
            }
            else
            {
                constraint.ForDelivery = null;
                constraint.ForInstore = null;
                constraint.ForInstorePreorder = null;
                constraint.ForTakeAway = null;
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }

        public ValidationResult PC_CollectionConstraint(PromotionConstraintViewModel constraint)
        {
            var notValid = new List<NotValidField>();

            if (constraint.HasCollectionConstraint)
            {
            }
            else
            {
            }

            if (notValid.Count == 0)
                return ValidationResult.Valid();
            return ValidationResult.NotValid(notValid);
        }
        #endregion

        public ValidationResult PromotionAwardDiscount(PromotionAwardDiscountViewModel discount)
        {
            throw new NotImplementedException();
        }

        public ValidationResult PromotionAwardGift(PromotionAwardGiftViewModel gift)
        {
            throw new NotImplementedException();
        }

        public ValidationResult PromotionAwardCashback(PromotionAwardCashbackViewModel cashback)
        {
            throw new NotImplementedException();
        }

    }

    public class NotValidField
    {
        [JsonProperty("code")]
        public MessageCode Code { get; set; }
        [JsonProperty("fields")]
        public IEnumerable<AppObject> Fields { get; set; }
        [JsonProperty("inner_message")]
        public string InnerMessage { get; set; }

        public static NotValidField From(MessageCode code, params AppObject[] fields)
        {
            var linker = " -> ";
            var mess = code.ToReadable();
            if (fields.Any())
            {
                mess += ": ";
                int i;
                for (i = 0; i < fields.Length - 1; i++)
                {
                    mess += fields[i].ToReadable() + linker;
                }
                mess += fields[i].ToReadable();
            }
            return new NotValidField()
            {
                InnerMessage = mess,
                Code = code,
                Fields = fields
            };
        }

        public static NotValidField From(MessageCode code, string linker, params AppObject[] fields)
        {
            var mess = code.ToReadable();
            if (fields.Any())
            {
                mess += ": ";
                int i;
                for (i = 0; i < fields.Length - 1; i++)
                {
                    mess += fields[i].ToReadable() + linker;
                }
                mess += fields[i].ToReadable();
            }
            return new NotValidField()
            {
                InnerMessage = mess,
                Code = code,
                Fields = fields
            };
        }

        public static NotValidField From(MessageCode code, string[] linkers, params AppObject[] fields)
        {
            var mess = code.ToReadable();
            if (fields.Any())
            {
                mess += ": ";
                int i;
                for (i = 0; i < fields.Length - 1; i++)
                {
                    mess += fields[i].ToReadable() + linkers[i];
                }
                mess += fields[i].ToReadable();
            }
            return new NotValidField()
            {
                InnerMessage = mess,
                Code = code,
                Fields = fields
            };
        }
    }

    public class ValidationResult
    {
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
        [JsonProperty("not_valid_fields")]
        public IEnumerable<NotValidField> NotValidFields { get; set; }

        public static ValidationResult Valid()
        {
            return new ValidationResult()
            {
                IsValid = true
            };
        }

        public static ValidationResult NotValid(IEnumerable<NotValidField> fields)
        {
            return new ValidationResult()
            {
                IsValid = false,
                NotValidFields = fields
            };
        }
    }
}
