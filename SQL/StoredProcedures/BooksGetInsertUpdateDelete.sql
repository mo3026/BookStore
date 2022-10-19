create or alter procedure BooksGetInsertUpdateDelete
	@bookID integer,
	@title nvarchar(255),
	@price decimal(12,0),
	@genre nvarchar(10),
	@publisherID integer,
	@statementtype nvarchar(255)
as
begin
    if (@statementtype='select')
	begin
        select *
        from Books;
    end
    if (@statementtype='get')
	begin
       select *
       from  Books
       where BookID=@bookID;
    end
    if(@statementtype='insert')
	begin
        insert into Books
        (
            Title,
            Price,
            Genre,
            PublisherID
        )
        values
        (
            @title,
            @price,
            @genre,
            @publisherID
        );
    end
    if(@statementtype='update')
	begin
        update Books
		set
            Title=@title,
			Price=@price,
			Genre=@genre,
			PublisherID=@publisherID
        where BookID=@bookID;
    end
    if(@statementtype='delete')
	begin
        delete Books where BookID=@bookID;
    end
end;