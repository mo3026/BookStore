create or alter procedure BookAuthorRelationGetInsertUpdateDelete
	@bookID integer,
	@authorID nvarchar(255),
	@statementtype nvarchar(255)
as
begin
    if (@statementtype='select')
	begin
        select *
        from BookAuthorRelation;
    end
    if(@statementtype='insert')
	begin
        insert into BookAuthorRelation
        (
            BookID,
            AuthorID
        )
        values
        (
            @bookID,
            @authorID
        );
    end
    if(@statementtype='delete')
	begin
        delete BookAuthorRelation where BookID=BookID or AuthorID=@authorID;
    end
end;