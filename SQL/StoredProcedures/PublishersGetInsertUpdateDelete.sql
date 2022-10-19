create or alter procedure PublishersGetInsertUpdateDelete
	@PublisherID integer,
	@title nvarchar(255),
	@statementtype nvarchar(255)
as
begin
    if (@statementtype='select')
	begin
        select *
        from Publishers;
    end
    if(@statementtype='insert')
	begin
        insert into Publishers
        (
            Title
        )
        values
        (
            @title
        );
    end
    if(@statementtype='update')
	begin
        update Publishers
		set
            Title=@title
        where PublisherID=@publisherID;
    end
    if(@statementtype='delete')
	begin
        delete Publishers where PublisherID=@publisherID;
    end
end;