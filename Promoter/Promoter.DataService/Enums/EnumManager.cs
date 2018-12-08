using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promoter.DataService.Enums
{
    public enum MessageCode
    {
        [Display(Name = "Thành công")]
        General_Success = 1,
        [Display(Name = "Thất bại")]
        General_Fail = 2,
        [Display(Name = "Lỗi chưa xác định")]
        General_Error = 3,
        [Display(Name = "Không được để trống")]
        Validation_BlankNotAllowed = 4,
        [Display(Name = "Đã tồn tại")]
        Validation_Existed = 5,
        [Display(Name = "Không hợp lệ")]
        Validation_NotValid = 6,
        [Display(Name = "Phải lớn hơn số 0")]
        Validation_MustGreatherThanZero = 7,
        [Display(Name = "Không được bỏ chọn")]
        Validation_MustBeChoosen = 8,
        [Display(Name = "Giá trị nhỏ nhất, lớn nhất không hợp lệ")]
        Validation_NotValidMinMaxValue = 9,
        [Display(Name = "Giá trị không được là số âm")]
        Validation_MustNotBeNegative = 10,
    }

    public enum AppObject
    {
        [Display(Name = "Mã khuyến mãi")]
        PromotionCode = 1,
        [Display(Name = "Tên khuyến mãi")]
        PromotionName = 2,
        [Display(Name = "Hình thức khuyến mãi")]
        PromotionDetail = 3,
        [Display(Name = "Số lượng áp dụng")]
        ApplyQuantity = 4,
        [Display(Name = "Số lượng voucher")]
        VoucherQuantity = 5,
        [Display(Name = "Độ dài mã voucher")]
        VoucherCodeLength = 6,
        [Display(Name = "Biểu mẫu mã voucher")]
        VoucherCodePattern = 7,
        [Display(Name = "Thuộc tính ràng buộc thời gian")]
        TimeConstraint = 8,
        [Display(Name = "Ngày bắt đầu và kết thúc")]
        BeginEndDate = 9,
        [Display(Name = "Thuộc tính ràng buộc về đơn đặt hàng")]
        OrderConstraint = 10,
        [Display(Name = "Tổng tiền tối thiểu, tối đa của đơn hàng")]
        MinMaxOrderAmount = 11,
        [Display(Name = "Số lượng người tối thiểu, tối đa")]
        MinMaxPersonCount = 12,
        [Display(Name = "Độ tuổi tối thiểu, tối đa")]
        MinMaxAge = 13,
        [Display(Name = "Sản phẩm")]
        Product = 14,
        [Display(Name = "Menu sản phẩm")]
        ProductMenu = 15,
        [Display(Name = "Danh mục sản phẩm")]
        ProductCategory = 16,
        [Display(Name = "Cấu hình lọc sản phẩm")]
        ProductFilter = 17,
        [Display(Name = "Thứ trong tuần")]
        DayOfWeek = 18,
        [Display(Name = "Giờ bắt đầu, kết thúc")]
        BeginEndTime = 19,
        [Display(Name = "Số lượng tối thiểu, tối đa")]
        MinMaxQuantity = 20,
        [Display(Name = "Thuộc tính ràng buộc về thanh toán")]
        PaymentConstraint = 21,
        [Display(Name = "Hình thức thanh toán")]
        PaymentType = 22,
        [Display(Name = "Thanh toán bên thứ ba")]
        PaymentPartner = 23,
        [Display(Name = "Số lượng sản phẩm tối thiểu, tối đa")]
        MinMaxProducts = 24,
        [Display(Name = "Thuộc tính ràng buộc Membership")]
        MembershipConstraint = 25,
        [Display(Name = "Cấp độ Membership")]
        MinMaxMembershipLevel = 26,
        [Display(Name = "Số điểm tối thiểu, tối đa")]
        MinMaxPoint = 27,
        [Display(Name = "Số ngày làm thành viên tối thiểu")]
        MinJoinDate = 28,
        [Display(Name = "Thuộc tính ràng buộc về hình thức bán hàng")]
        SaleModeConstraint = 29,
        [Display(Name = "Thuộc tính ràng buộc về các bộ sưu tập")]
        CollectionConstraint = 30,
    }

    public enum DoW //Day of week
    {
        All = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7,
        Sunday = 8,
    }

    public enum PaymentType
    {
        Cash = 1,
        Membership = 2,
        EWallet = 3,
    }

    public static class EnumExtensions
    {
        public static string ToReadable(this MessageCode code)
        {
            switch (code)
            {
                case MessageCode.General_Success: return "Thành công";
                case MessageCode.General_Fail: return "Thất bại";
                case MessageCode.General_Error: return "Lỗi chưa xác định";
                case MessageCode.Validation_BlankNotAllowed: return "Không được để trống";
                case MessageCode.Validation_Existed: return "Đã tồn tại";
                case MessageCode.Validation_NotValid: return "Không hợp lệ";
                case MessageCode.Validation_MustGreatherThanZero: return "Phải lớn hơn số 0";
                case MessageCode.Validation_MustBeChoosen: return "Không được bỏ chọn";
                case MessageCode.Validation_NotValidMinMaxValue: return "Giá trị nhỏ nhất, lớn nhất không hợp lệ";
                case MessageCode.Validation_MustNotBeNegative: return "Giá trị không được là số âm";
            }
            return null;
        }

        public static string ToReadable(this AppObject obj)
        {
            switch (obj)
            {
                case AppObject.PromotionCode: return "Mã khuyến mãi";
                case AppObject.PromotionName: return "Tên khuyến mãi";
                case AppObject.PromotionDetail: return "Hình thức khuyến mãi";
                case AppObject.ApplyQuantity: return "Số lượng áp dụng";
                case AppObject.VoucherQuantity: return "Số lượng voucher";
                case AppObject.VoucherCodeLength: return "Độ dài mã voucher";
                case AppObject.VoucherCodePattern: return "Biểu mẫu mã voucher";
                case AppObject.TimeConstraint: return "Thuộc tính ràng buộc thời gian";
                case AppObject.BeginEndDate: return "Ngày bắt đầu và kết thúc";
                case AppObject.OrderConstraint: return "Thuộc tính ràng buộc về đơn đặt hàng";
                case AppObject.MinMaxOrderAmount: return "Tổng tiền tối thiểu, tối đa của đơn hàng";
                case AppObject.MinMaxPersonCount: return "Số lượng người tối thiểu, tối đa";
                case AppObject.MinMaxAge: return "Độ tuổi tối thiểu, tối đa";
                case AppObject.Product: return "Sản phẩm";
                case AppObject.ProductMenu: return "Menu sản phẩm";
                case AppObject.ProductCategory: return "Danh mục sản phẩm";
                case AppObject.ProductFilter: return "Cấu hình lọc sản phẩm";
                case AppObject.DayOfWeek: return "Thứ trong tuần";
                case AppObject.BeginEndTime: return "Giờ bắt đầu, kết thúc";
                case AppObject.MinMaxQuantity: return "Số lượng tối thiểu, tối đa";
                case AppObject.PaymentConstraint: return "Thuộc tính ràng buộc về thanh toán";
                case AppObject.PaymentType: return "Hình thức thanh toán";
                case AppObject.PaymentPartner: return "Thanh toán bên thứ ba";
                case AppObject.MinMaxProducts: return "Số lượng sản phẩm tối thiểu, tối đa";
                case AppObject.MembershipConstraint: return "Thuộc tính ràng buộc Membership";
                case AppObject.MinMaxMembershipLevel: return "Cấp độ Membership";
                case AppObject.MinMaxPoint: return "Số điểm tối thiểu, tối đa";
                case AppObject.MinJoinDate: return "Số ngày làm thành viên tối thiểu";
                case AppObject.SaleModeConstraint: return "Thuộc tính ràng buộc về hình thức bán hàng";
                case AppObject.CollectionConstraint: return "Thuộc tính ràng buộc về các bộ sưu tập";
            }
            return null;
        }

        public static bool IsInPaymentTypeEnum(this int intVal)
        {
            switch (intVal)
            {
                case (int)PaymentType.Cash:
                case (int)PaymentType.EWallet:
                case (int)PaymentType.Membership:
                    return true;
            }
            return false;
        }
    }

}
