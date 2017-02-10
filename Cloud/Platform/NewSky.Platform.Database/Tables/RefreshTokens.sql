CREATE TABLE [dbo].[RefreshTokens]
(
	[Id] VARCHAR(100) NOT NULL PRIMARY KEY, 
    [Subject] VARCHAR(100) NOT NULL, 
    [ClientId] VARCHAR(100) NOT NULL, 
    [IssuedUtc] DATETIME NOT NULL, 
    [ExpiresUtc] DATETIME NOT NULL, 
    [ProtectedTicket] VARCHAR(MAX) NOT NULL
)
