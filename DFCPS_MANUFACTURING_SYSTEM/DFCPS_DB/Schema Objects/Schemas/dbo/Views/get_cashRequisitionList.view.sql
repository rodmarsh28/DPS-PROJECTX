CREATE VIEW [dbo].[get_cashRequisitionList] AS select distinct convert(varchar,TRANSDATE,111) as DATE,CRSNO as No,tblCardsProfile.cardname as Cardname,totalamountapplied as Total_Amount,status as Status
from tblCashRequisition
inner join tblCardsProfile on tblCashRequisition.CARDID = tblCardsProfile.CARDID