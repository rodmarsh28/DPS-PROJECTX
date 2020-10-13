CREATE PROCEDURE [dbo].[get_cash_requisition_list]
@command as varchar(255),
@searchValue as varchar(255)
AS
BEGIN if @command = 0 begin
select distinct convert(varchar,TRANSDATE,111) as DATE,CRSNO as No,tblCardsProfile.cardname as Cardname,totalamountapplied as Total_Amount,status as Status
from tblCashRequisition
inner join tblCardsProfile on tblCashRequisition.CARDID = tblCardsProfile.CARDID
where  CRSNO like '%' + @searchValue + '%' OR tblCashRequisition.CARDID like '%' + @searchValue + '%'
end
else if @command = 1 begin
select crsno,tblCardsProfile.cardid,cardname,cardAddress,totalamountapplied,particulars,amount,amountApplied,REMARKS
from tblCashRequisition
inner join tblCardsProfile on tblCashRequisition.CARDID = tblCardsProfile.CARDID
where  CRSNO like '%' + @searchValue + '%' OR tblCashRequisition.CARDID like '%' + @searchValue + '%'
end
else if @command = 2 begin
select crsno,transdate,tblCashRequisition.CARDID,tblCardsProfile.cardName,particulars,amount,amountApplied,remarks,TOTALAMOUNT,TOTALAMOUNTAPPLIED,notimesedit
from tblCashRequisition
inner join tblCardsProfile on tblCashRequisition.CARDID = tblCardsProfile.cardID
where CRSNO = @searchValue
end
END