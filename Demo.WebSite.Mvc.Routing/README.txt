



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

USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[spGetCertifiedItems]    Script Date: 10/17/2016 06:44:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetCertifiedBatches]
as
begin
	select	*
	from	tblCertifiedBatch (nolock)
end
GO

USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[spGetCertifiedItems]    Script Date: 10/17/2016 06:51:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetCertifiedItems]
	@CertifiedBatchID	int
as
begin
	select	*
	from	tblCertifiedItem ci (nolock)
	where	ci.CertifiedBatchID = @CertifiedBatchID
end


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

GO


create table Pending 
(
	ID					int identity(1, 1) primary key,
	CertifiedItemID		int not null
)
GO

insert	Pending(CertifiedItemID) select 1
insert	Pending(CertifiedItemID) select 2
insert	Pending(CertifiedItemID) select 7
insert	Pending(CertifiedItemID) select 8

GO


USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[spGetCertifiedItems]    Script Date: 10/21/2016 05:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetCertifiedItems]
	@CertifiedBatchID	int
as
begin
	select	ci.CertifiedItemID, CertifiedBatchID, Address,
			State, Zip, ImagePath,
			DateCreated, IsVoided = case when p.ID is null then 0 else 1 end
	from	tblCertifiedItem ci (nolock)
			left join Pending p (nolock) on p.CertifiedItemID = ci.CertifiedItemID
	where	ci.CertifiedBatchID = @CertifiedBatchID
end

GO



declare	@counter int  = 6
while @counter <= 100 begin

	declare	@batchID int
	insert tblCertifiedBatch default values

	select	@batchID = SCOPE_IDENTITY()
	declare	@counterString varchar(100) = cast(@batchID as varchar)

	insert tblCertifiedItem(CertifiedBatchID, Address, State, Zip) select @batchID, 'a' + @counterString, 's' + @counterString, replicate(@counterString, 5)

	set @counter = @counter + 1
end


select	*
from	tblCertifiedItem

select	*
from	tblCertifiedBatch








