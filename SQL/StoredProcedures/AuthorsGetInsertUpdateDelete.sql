create or alter procedure AuthorsGetInsertUpdateDelete
	@authorID integer,
	@firstName nvarchar(255),
	@lastName nvarchar(255),
	@statementtype nvarchar(255)
as
begin
    if (@statementtype='select')
	begin
        select *
        from Authors;
    end
    if (@statementtype='get')
	begin
       select *
       from  Authors
       where AuthorID=@authorID;
    end
    if(@statementtype='insert')
	begin
        insert into Authors
        (
            FirstName,
            LastName
        )
        values
        (
            @firstName,
            @lastName
        );
    end
    if(@statementtype='update')
	begin
        update Authors
		set
            FirstName=@firstName,
			LastName=@lastName
        where AuthorID=@authorID;
    end
    if(@statementtype='delete')
	begin
        delete Authors where AuthorID=@authorID;
    end
end;