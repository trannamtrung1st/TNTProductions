--CREATE DATABASE TPromoter;
USE TPromoter;

--1 promotion: chương trình khuyến mãi
CREATE TABLE Promotion (
	PromotionId int IDENTITY(1,1) PRIMARY KEY,

	--begin attributes
	PromotionCode varchar(250) NOT NULL,
	PromotionName nvarchar(250) NOT NULL,
	Description nvarchar(250),
	ImageCss nvarchar(50),
	ImageUrl nvarchar(max),
	BrandId int,
	Active bit NOT NULL,
	--end attributes
);

-- 1 promotion - N detail => nhiều hình thức (OR)
CREATE TABLE PromotionDetail (
	PromotionDetailId int IDENTITY(1,1) PRIMARY KEY,

	--begin attributes
	DetailCode nvarchar(250) NOT NULL,
	Description nvarchar(250),
	ApplyQuantity int,
	AppliedQuantity int,
	HasVoucher bit NOT NULL,
	VoucherQuantity int,
	VoucherUsedQuantity int,

	AwardDiscount bit NOT NULL,
	AwardGift bit NOT NULL,
	AwardCashback bit NOT NULL,
	--end attributes

	--begin voucher config
	AutoGenLength int,
	Prefix nvarchar(100),
	Postfix nvarchar(100),
	Pattern nvarchar(100),
	--end voucher config
	
	PromotionPartnerId int,
	PromotionId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionId) REFERENCES Promotion(PromotionId)
);

--1 detail - N Award => áp dụng chung các Award (AND)
CREATE TABLE PromotionAwardDiscount (
	PromotionAwardId int IDENTITY(1,1) PRIMARY KEY,
	
	--begin attributes
	ForProductId int,
	BuyXGetYAmount int,
	FixedUpsizePrice float,
	SyncPrice float,
	DiscountAmout float,
	DiscountPercent float,
	ShipDiscount float,
	--end attributes

	PromotionDetailId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId)
);

CREATE TABLE PromotionAwardGift (
	PromotionAwardId int IDENTITY(1,1) PRIMARY KEY,
	
	--begin attributes
	ForProductId int,
	GiftVoucherId int,
	GiftVoucherOfPromotionId int,
	GiftPresentId int,
	GiftProductId int,
	--end attributes

	PromotionDetailId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId),
);

CREATE TABLE PromotionAwardCashback (
	PromotionAwardId int IDENTITY(1,1) PRIMARY KEY,
	
	--begin attributes
	ForProductId int,
	CustomerCashbackMode int,
    CustomerCashbackAccountType int,
    CustomerCashbackAmount float,
    MaxCustomerCashbackAmount float,
    AffliatorCashbackMode int,
    AffliatorCashbackAccountType int,
	AffliatorCashbackAmount float,
	MaxAffliatorCashbackAmount float,
	--end attributes

	PromotionDetailId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId),
);

--1 detail - N voucher
CREATE TABLE Voucher (
	VoucherId int IDENTITY(1,1) PRIMARY KEY,
	--begin attributes
	VoucherCode nvarchar(250) NOT NULL,
	GeneratedDate datetime,
	ExpiredDate datetime,
	ApplyQuantity int NOT NULL,
	AppliedQuantity int NOT NULL,
    IsGetted bit NOT NULL,
    MembershipCode nvarchar(250),
	--end attributes

	PromotionDetailId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId)
);

/*
--1 detail - N stamp
CREATE TABLE _Stamp (
	StampId int PRIMARY KEY,
	--attributes

	PromotionDetailId int,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId),	
);

--1 stamp - N collection
CREATE TABLE _StampCollection (
	StampCollectionId int PRIMARY KEY,
	--attributes

	StampId int,
	FOREIGN KEY (StampId) REFERENCES _Stamp(StampId),	
);

--con dấu điện tử phát cho cửa hàng , ...
CREATE TABLE _ElectronicStamp (
	ElectronicStampId int PRIMARY KEY,
	--attributes
	--references
);
*/

--1 detail - N constraint => 1 trong số điều kiện (OR)
CREATE TABLE PromotionConstraint (
	ConstraintId int IDENTITY(1,1) PRIMARY KEY,
	
	HasTimeContraint bit not null,
	PromotionBeginDate datetime,
	PromotionEndDate datetime,
	--additional daytime filter

	HasOrderConstraint bit not null,
	FixProductFilter bit, --đúng với những món có trong filter sản phẩm, false thì có quyền hơn
	--additional product filter
	MinTotalProducts int,
	MaxTotalProducts int,
	MinTotalAmount float,
	MaxTotalAmount float,
	MinPersonCount int,
	MaxPersonCount int,
	Gender bit,
	MinAge int,
	MaxAge int,
	--HasPersonConstraint bit not null,
	
	HasPaymentConstraint bit not null,
	PaymentType int,
	PaymentPartnerCode nvarchar(250),

	HasStoreConstraint bit not null,
	--additional store filter
	
	HasMembershipConstraint bit not null,
	MembershipCode nvarchar(250),
	MembershipTypeCode nvarchar(250),
	MembershipCodePattern nvarchar(max), --pattern có thể check nhiều dạng code 
	MembershipMinLevel int,
	MembershipMaxLevel int,
	MinPoint float,
	MaxPoint float,
	MinJoinDate int,

	HasSaleModeConstraint bit not null,
	ForTakeAway bit,
	ForDelivery bit,
	ForInstore bit,
	ForInstorePreorder bit,

	HasCollectionConstraint bit not null,
	--constraint attributes

	PromotionDetailId int,
	Active bit NOT NULL,
	FOREIGN KEY (PromotionDetailId) REFERENCES PromotionDetail(PromotionDetailId)					
);

CREATE TABLE PC_DateTimeFilter(
	FilterId int IDENTITY(1,1) PRIMARY KEY,

	--begin attributes
	BeginDate datetime,
	EndDate datetime,
	DayOfWeek int, --Từ 2->8: thứ, 0: áp dụng tất cả các thứ trong tuần
	BeginHour time,
	EndHour time,
	--end attributes

	ConstraintId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (ConstraintId) REFERENCES PromotionConstraint(ConstraintId)					
);

CREATE TABLE PC_ProductFilter(
	FilterId int IDENTITY(1,1) PRIMARY KEY,
	
	--begin attributes
	ProductId int,
	ProductCategoryId int,
	ProductMenuId int,
	MinBuyQuantity int,
	MaxBuyQuantity int,
	--end attributes
	
	ConstraintId int NOT NULL,
	Active bit NOT NULL,
	FOREIGN KEY (ConstraintId) REFERENCES PromotionConstraint(ConstraintId),
);

CREATE TABLE PC_StoreFilter(
	StoreId int,
	ConstraintId int NOT NULL,
	Active bit NOT NULL,
	PRIMARY KEY (StoreId, ConstraintId),
	FOREIGN KEY (ConstraintId) REFERENCES PromotionConstraint(ConstraintId),
);
