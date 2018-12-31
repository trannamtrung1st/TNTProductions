ALTER TABLE PromotionDetal
ADD Description nvarchar(MAX)

ALTER TABLE Promotion
ADD AllowApplyWithOthers bit
EXEC sp_RENAME 'PromotionDetail.RegExCode', 'MembershipCodePattern', 'COLUMN';
