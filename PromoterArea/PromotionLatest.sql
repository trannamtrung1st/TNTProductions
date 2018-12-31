--PROMOTION
ALTER TABLE Promotion 
ADD 

	/*begin voucher config*/
	VoucherLength int,
	Prefix nvarchar(100),
	Postfix nvarchar(100),
	AllowAutoCreateVoucher bit,
	VoucherAllowUseQuantity int,
	VoucherPattern nvarchar(100),
	VoucherExpiredAfterHours int,
	/*end voucher config*/

	HasTimeAttributes bit, --NOT NULL,
	HasPaymentAttributes bit,--NOT NULL
	HasSaleModeAttributes bit, --NOT NULL
	HasEventAttributes bit,
	AllowApplyWithOthers bit,
	BeginTime time,
	EndTime time,
	DaysOfWeek varchar(20),
	PaymentTypes varchar(100),
	PaymentPartnerId int,
	OrderTypes nvarchar(100),
	EventValues varchar(100),
	CanApplyPerPoints float,

	DetailApplyType int,
	CreatedDate datetime,
	AdjustedDate datetime,
	ApplyQuantity int,
	AppliedQuantity int;

/*ALTER TABLE Promotion
DROP COLUMN [PromotionClassName]
      ,[GiftType]
      ,[FromHappyDay]
      ,[ToHappyDay]
      ,[FromHoursHappy]
      ,[ToHoursHappy]
      ,[UsingPoint]
      ,[PartnerID]; -- xoa tay*/

--PROMOTION DETAIL
ALTER TABLE PromotionDetail
ADD	
	DetailLevel int
	,PromotionId int --temp
	,CreatedDate datetime
	,AdjustedDate datetime
	,Description nvarchar(250)
	,Active bit --NOT NULL
	,VoucherQuantity int
	,VoucherUsedQuantity int
	,VoucherExpiredAfterHours int
	
	,HasTimeAttributes bit --NOT NULL,
	,BeginDate datetime
	,EndDate datetime
	,DaysOfWeek varchar(20)
	,BeginHour time
	,EndHour time,

	HasOrderAttributes bit, --NOT NULL,
	BuyProductCategoryId int,
	BuyProductCollectionId int,
	IsCollectionAndRelationship bit, --true: and, false: or
	MinPersonCount int,
	MaxPersonCount int,
	Gender bit,
	MinAge int,
	MaxAge int,

	HasPaymentAttributes bit,--NOT NULL
	PaymentTypes varchar(100),
	PaymentPartnerId int,

	HasMembershipAttributes bit, --NOT NULL
	MembershipCode nvarchar(250),
	MembershipTypeCode nvarchar(250),
	MembershipMinLevel int,
	MembershipMaxLevel int,

	HasSaleModeAttributes bit, --NOT NULL
	OrderTypes nvarchar(100),

	HasCollectionAttributes bit, --NOT NULL,

	HasEventAttributes bit,
	EventValues varchar(100),
	CanApplyPerPoints float,

	/*begin voucher config*/
	VoucherLength int,
	Prefix nvarchar(100),
	Postfix nvarchar(100),
	AllowAutoCreateVoucher bit,
	VoucherAllowUseQuantity int,
	VoucherPattern nvarchar(100),
	/*end voucher config*/
	
	PromotionPartnerId int NULL;

EXEC sp_RENAME 'PromotionDetail.RegExCode', 'MembershipCodePattern', 'COLUMN';

/*ALTER TABLE PromotionDetail
DROP COLUMN  [GiftProductCode] --x
      ,[GiftQuantity]--x
      ,[DiscountRate]--x
      ,[DiscountAmount]--x
      ,[PointTrade]--x
      ,[CustomerCashbackMode] --x
      ,[CustomerCashbackAccountType] --x
      ,[CustomerCashbackAmount] --x 
      ,[MaxCustomerCashbackAmount]--x
      ,[AffliatorCashbackMode]--x
      ,[AffliatorCashbackAccountType]--x
      ,[AffliatorCashbackAmount]--x
      ,[MaxAffliatorCashbackAmount]--x*/

--VOUCHER
ALTER TABLE Voucher
ADD
	IssuedStoreId int,
	ApplyType int,
	IssuedTime datetime,
	LatestUsedTime datetime,
	GeneratedTime datetime,
	GettedTime datetime,
	ExpiredTime datetime,
	MembershipCode nvarchar(250);
EXEC sp_RENAME 'Voucher.MembershipCardID', 'MembershipID', 'COLUMN';

CREATE TABLE CustomerEvents (
	Id int IDENTITY(1,1) PRIMARY KEY,
	CustomerCode nvarchar(250),
	MembershipCode nvarchar(250),
	EventType int,
	FromLevel int,
	ToLevel int,
	FromType int,
	ToType int,
	Amount float,
	AwardedPromotionCode nvarchar(MAX),
	AwardedPromotionDetailCode nvarchar(MAX),
	HappenedDate datetime,

	CustomerId int NOT NULL,
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
);

/*ALTER TABLE Voucher
DROP COLUMN	
	[isUsed]--x
	,[PromotionID]--xoa tay*/

CREATE TABLE PromotionAward (
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
	GiftVoucherOfPromotionDetailCode nvarchar(250),
	GiftVoucherOfPromotionCode nvarchar(250),
	GiftVoucherQuantity int,
	GiftProductCode nvarchar(250),
	GiftProductQuantity int,

	AwardCashback bit NOT NULL,
	CashbackForProductCode nvarchar(250),
	CustomerCashbackMode int,
    CustomerCashbackAccountType int,
    CustomerCashbackAmount float,
	CustomerAmountPerXVND float,
    MaxCustomerCashbackAmount float,
    AffliatorCashbackMode int,
    AffliatorCashbackAccountType int,
	AffliatorCashbackAmount float,
	MaxAffliatorCashbackAmount float,
	AffliatorAmountPerXVND float,
	/*end attributes*/

	Active bit,
	PromotionDetailId int NOT NULL,
	FOREIGN KEY (PromotionDetailID) REFERENCES PromotionDetail(PromotionDetailID),
);

/*
ALTER TABLE PromotionDetail WITH NOCHECK ADD CONSTRAINT FL_PromotionOfDetail
FOREIGN KEY (PromotionId) REFERENCES Promotion(PromotionId);
ALTER TABLE PromotionDetail WITH NOCHECK ADD CONSTRAINT FL_ProductCategoryPromotionDetail
FOREIGN KEY (BuyProductCategoryId) REFERENCES ProductCategory(CateId);
ALTER TABLE PromotionDetail WITH NOCHECK ADD CONSTRAINT FL_ProductCollectionPromotionDetail
FOREIGN KEY (BuyProductCollectionId) REFERENCES ProductCollection(Id);
ALTER TABLE PromotionDetail WITH NOCHECK ADD CONSTRAINT FL_PaymentPartnerPromotionDetail
FOREIGN KEY (PaymentPartnerId) REFERENCES PaymentPartner(Id);
ALTER TABLE PromotionDetail WITH NOCHECK ADD CONSTRAINT FL_PromotionPartnerPromotionDetail
FOREIGN KEY (PromotionPartnerId) REFERENCES Partner(Id);
ALTER TABLE Promotion ALTER COLUMN ApplyLevel INTEGER NULL
*/