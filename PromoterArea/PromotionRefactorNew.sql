/*1 promotion: chương trình khuyến mãi*/
CREATE TABLE _Promotion (
	PromotionId int IDENTITY(1,1) PRIMARY KEY,

	/*begin attributes*/
	PromotionCode varchar(250) NOT NULL,
	PromotionName nvarchar(250) NOT NULL,
	CreatedDate datetime,
	FromDate datetime,
	ToDate datetime,
	AdjustedDate datetime,
	ApplyQuantity int,
	AppliedQuantity int,
	Description nvarchar(250),
	ImageCss nvarchar(50),
	ImageUrl nvarchar(max),
	Active bit NOT NULL,
	BrandId int,
	PromotionType int,
	/*end attributes*/

	FOREIGN KEY (BrandId) REFERENCES Brand(Id)
);

/*1 promotion - N detail => nhiều hình thức (OR)*/
CREATE TABLE _PromotionDetail (
	PromotionDetailId int IDENTITY(1,1) PRIMARY KEY,
	
	/*begin attributes*/
	CreatedDate datetime,
	AdjustedDate datetime,
	DetailCode nvarchar(250) NOT NULL,
	Description nvarchar(250),
	Active bit NOT NULL,
	HasVoucher bit NOT NULL,
	VoucherQuantity int,
	VoucherUsedQuantity int,
	VoucherExpiredAfterHours int,

	HasTimeAttributes bit not null,
	BeginDate datetime,
	EndDate datetime,
	DaysOfWeek varchar(20), -- T2T4T6
	BeginHour time,
	EndHour time,

	HasOrderAttributes bit not null,
	BuyProductCode nvarchar(250) NULL,
	BuyProductCategoryId int NULL,
	BuyProductCollectionId int NULL,
	IsCollectionAndRelationship bit, --true: and, false: or
	MinBuyQuantity int,
	MaxBuyQuantity int,
	MinTotalAmount float,
	MaxTotalAmount float,
	MinPersonCount int,
	MaxPersonCount int,
	Gender bit,
	MinAge int,
	MaxAge int,
	
	HasPaymentAttributes bit not null,
	PaymentType int,
	PaymentPartnerCode nvarchar(250),

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
	VoucherLength int,
	Prefix nvarchar(100),
	Postfix nvarchar(100),
	VoucherPattern nvarchar(100),
	/*end voucher config*/
	
	PromotionPartnerId int NULL,

	PromotionId int NOT NULL,
	FOREIGN KEY (PromotionId) REFERENCES _Promotion(PromotionId),
	FOREIGN KEY (BuyProductCategoryId) REFERENCES ProductCategory(CateID),
	FOREIGN KEY (BuyProductCollectionId) REFERENCES ProductCollection(Id),
	FOREIGN KEY (PromotionPartnerId) REFERENCES Partner(Id),
);

CREATE TABLE _PromotionAward (
	PromotionAwardId int IDENTITY(1,1) PRIMARY KEY,
	
	/*begin attributes*/
	AwardDiscount bit NOT NULL,
	DiscountForProductCode nvarchar(250),
	BuyXGetYAmount int,
	FixedUpsizePrice float,
	SyncPrice float,
	DiscountAmout float,
	DiscountPercent float,
	ShipDiscount float,

	AwardGift bit NOT NULL,
	GiftForProductCode nvarchar(250),
	GiftVoucherOfPromotionDetailId int,
	GiftVoucherQuantity int,
	GiftProductCode nvarchar(250),
	GiftProductQuantity int,

	AwardCashback bit NOT NULL,
	CashbackForProductCode nvarchar(250),
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
	FOREIGN KEY (GiftVoucherOfPromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId),
);

/*1 detail - N voucher*/
CREATE TABLE _Voucher (
	VoucherId int IDENTITY(1,1) PRIMARY KEY,
	/*begin attributes*/
	VoucherCode nvarchar(250) NOT NULL,
	GeneratedTime datetime,
	ExpiredTime datetime,
	ApplyQuantity int NOT NULL,
	AppliedQuantity int NOT NULL,
    IsGetted bit NOT NULL,
    MembershipCode nvarchar(250),
	Active bit NOT NULL,
	/*end attributes*/

	PromotionDetailId int NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId)
);

ALTER TABLE OrderDetailPromotionMapping 
ADD _PromotionDetailId int,
FOREIGN KEY (_PromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId);

ALTER TABLE OrderPromotionMapping 
ADD _PromotionDetailId int,
FOREIGN KEY (_PromotionDetailId) REFERENCES _PromotionDetail(PromotionDetailId);

ALTER TABLE PromotionStoreMapping 
ADD _PromotionId int,
FOREIGN KEY (_PromotionId) REFERENCES _Promotion(PromotionId);