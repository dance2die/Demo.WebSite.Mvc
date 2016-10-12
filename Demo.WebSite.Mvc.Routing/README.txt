



create table tblCertifiedBatch
(
	CertifiedBatchID	int identity(1, 1) primary key,
	DateCreated			datetime default getdate()
)
GO

--drop table tblCertifiedItem
create table tblCertifiedItem
(
	CertifiedItemID		int identity(1, 1) primary key,
	CertifiedBatchID	int references tblCertifiedBatch(CertifiedBatchID),
	Address				varchar(200),
	State				varchar(10),
	Zip					varchar(10),
	ImagePath			nvarchar(1000),
	DateCreated			datetime default getdate()
)
GO


create procedure spGetCertifiedItems
as
begin
	select	*
	from	tblCertifiedItem ci (nolock)
end
GO

create procedure spGetCertifiedItem
	@CertifiedItemID	int
as
begin
	select	*
	from	tblCertifiedItem ci (nolock)
	where	ci.CertifiedItemID = @CertifiedItemID
end
GO


insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 1, 'a1', 's1', '11111'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 1, 'a1', 's1', '11111'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 1, 'a1', 's1', '11111'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 1, 'a1', 's1', '11111'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 1, 'a1', 's1', '11111'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 2, 'a2', 's2', '22222'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 2, 'a2', 's2', '22222'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 2, 'a2', 's2', '22222'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 2, 'a2', 's2', '22222'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 3, 'a3', 's3', '33333'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 3, 'a3', 's3', '33333'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 3, 'a3', 's3', '33333'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 4, 'a4', 's4', '44444'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 4, 'a4', 's4', '44444'
insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select 5, 'a5', 's5', '55555'












