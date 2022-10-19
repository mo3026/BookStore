create or alter procedure BooksSearch
	@columnName nvarchar(255),
	@value nvarchar(255)
as
begin
declare @Sql nvarchar(max)
set @Sql = 'select * from Books where '+@columnName+' like ''%'+@value+'%'''
exec sp_executesql @Sql
end;
