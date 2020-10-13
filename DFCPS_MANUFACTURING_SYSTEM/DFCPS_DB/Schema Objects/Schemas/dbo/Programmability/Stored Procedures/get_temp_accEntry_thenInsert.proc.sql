CREATE PROCEDURE [dbo].[get_temp_accEntry_thenInsert]
@refno varchar(255),
@src varchar(255),
@userID varchar(255)
AS
BEGIN

insert into tblAccEntry (dateTrans,b.refno,src,b.accno,b.memo,b.debit,b.credit,userid)
select convert(varchar,getdate(),111) as dateTrans,b.refno,@src as src,b.accno,b.memo,b.debit,b.credit,@userid as userid

from tblPendingAccEntry b
where b.refno = @refNo
END