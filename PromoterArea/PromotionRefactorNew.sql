/*1 promotion: chương trình khuyến mãi*/
CREATE TABLE _Promotion (
	PromotionId int PRIMARY KEY,

	/*begin attributes*/
	PromotionCode varchar(250) NOT NULL,
	PromotionName nvarchar(250) NOT NULL,
	Description nvarchar(250),
	ImageCss nvarchar(50),
	ImageUrl nvarchar(max),
	Active bit NOT NULL,
	BrandId int,
	/*end attributes*/
);

/*1 promotion - N detail => nhiều hình thức (OR)*/
CREATE TABLE _PromotionDetail (
	PromotionDetailId int PRIMARY KEY,

	/*begin attributes*/
	DetailCode nvarchar(250) NOT NULL,
	Description nvarchar(250),
	Active bit NOT NULL,
	ApplyQuantity int,
	AppliedQuantity int,
	HasVoucher bit NOT NULL,
	VoucherQuantity int,
	VoucherUsedQuantity int,

	HasTimeAttributes bit not null,
	BeginDate datetime,
	EndDate datetime,
	DaysOfWeek varchar(20), /*Từ 2->8: thứ, 0: áp dụng tất cả các thứ trong tuần*/
	BeginHour time, /*có thể có nhiều khung giờ trong ngày*/
	EndHour time,
	/*additional daytime filter*/

	HasOrderAttributes bit not null,
	ProductsId varchar(max), /*có thể có nhiều product*/
	ProductCategoryId varchar(max),
	ProductMenuId varchar(max), 
	MinBuyQuantity int,
	MaxBuyQuantity int,
	MinTotalAmount float,
	MaxTotalAmount float,
	PersonCount int,
	Gender bit,
	MinAge int,
	MaxAge int,
	
	HasPaymentAttributes bit not null,
	PaymentType int,
	PaymentPartnerCode nvarchar(250),

	HasStoreAttributes bit not null,
	/*promotion store mapping*/
	
	HasMembershipAttributes bit not null,
	MembershipCode nvarchar(250),
	MembershipTypeCode nvarchar(250),
	MembershipCodePattern nvarchar(max), /*pattern có thể check nhiều dạng code*/ 
	MembershipMinLevel int,
	MembershipMaxLevel int,
	MinPoint float,
	MaxPoint float,

	HasSaleModeAttributes bit not null,
	ForTakeAway bit,
	ForDelivery bit,
	ForInstore bit,
	ForInstorePreorder bit,

	HasCollectionAttributes bit not null,

	/*begin voucher config*/
	Length int,
	Prefix int,
	Postfix int,
	Pattern nvarchar(100),
	/*end voucher config*/
	
	/*PromotionPartnerId int,*/
	PromotionId int NOT NULL,
	FOREIGN KEY (PromotionId) REFERENCES _Promotion(PromotionId)
);

CREATE TABLE _PromotionAward (
	PromotionAwardId int PRIMARY KEY,
	
	/*begin attributes*/
	AwardDiscount bit NOT NULL,
	DiscountForProductId int,
	BuyXGetYAmount int,
	FixedUpsizePrice float,
	SyncPrice float,
	DiscountAmout float,
	DiscountPercent float,
	ShipDiscount float,

	AwardGift bit NOT NULL,
	GiftForProductId int,
	GiftVoucherId int,
	GiftVoucherOfPromotionId int,
	GiftVoucherQuantity int,
	GiftPresentId int,
	GiftPresentQuantity int,
	GiftProductId int,
	GiftProductQuantity int,

	AwardCashback bit NOT NULL,
	CashbackForProductId int,
	CustomerCashbackMode int,
    CustomerCashbackAccountType int,
    CustomerCashbackAmount float,
    MaxCustomerCashbackAmount float,
    AffliatorCashbackMode int,
    AffliatorCashbackAccountType int,
	AffliatorCashbackAmount float,
	MaxAffliatorCashbackAmount float,
	/*end attributes*/

	PromotionDetailId int NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId),
);

/*1 detail - N voucher*/
CREATE TABLE _Voucher (
	VoucherId int PRIMARY KEY,
	/*begin attributes*/
	VoucherCode nvarchar(250) NOT NULL,
	GeneratedDate datetime,
	ExpiredDate datetime,
	ApplyQuantity int NOT NULL,
	AppliedQuantity int NOT NULL,
    IsGetted bit NOT NULL,
    MembershipCode nvarchar(250),
	Active bit NOT NULL,
	/*end attributes*/

	PromotionDetailId int NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId)
);
