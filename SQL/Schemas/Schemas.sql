create table Publishers
(
	PublisherID  integer NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR (255) NOT NULL,
	CONSTRAINT UniquePublisher UNIQUE (Title)
);

create table Authors
(
	AuthorID integer NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR (255) not NULL,
	LastName NVARCHAR (255) not NULL,
	CONSTRAINT UniqueAuthor UNIQUE (FirstName,LastName)
)

create table Books
(
	BookID integer NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title nvarchar(255) not null,
	Price decimal(12,0) not null,
	Genre nvarchar(10) CHECK(Genre IN ('Sci-Fi','Thriller','Romance')),
	PublisherID INTEGER,
	CONSTRAINT fk_PublisherID
		FOREIGN KEY (PublisherID)
		REFERENCES Publishers(PublisherID)
)


create table BookAuthorRelation
(
	BookID integer,
	AuthorID integer,
	PRIMARY KEY (BookID,AuthorID),
	CONSTRAINT fk_BookID
		FOREIGN KEY (BookID)
		REFERENCES Books(BookID),
	CONSTRAINT fk_AuthorID
		FOREIGN KEY (AuthorID)
		REFERENCES Authors(AuthorID)
);