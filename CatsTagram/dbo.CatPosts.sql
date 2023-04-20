CREATE TABLE [dbo].[CatPosts] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [AuthorName]       NVARCHAR (MAX) NOT NULL,
    [AuthorEmail]      NVARCHAR (MAX) NULL,
    [Comment]          NVARCHAR (255) NOT NULL,
    [DateAdded]        DATETIME2 (7)  NOT NULL,
    [ImageData]        NVARCHAR (MAX) NOT NULL,
    [ImageContentType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CatPosts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

