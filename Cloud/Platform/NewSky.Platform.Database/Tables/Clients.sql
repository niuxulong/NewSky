CREATE TABLE [dbo].[Clients]
(
	[Id] VARCHAR(128) NOT NULL PRIMARY KEY, 
    [Secret] VARCHAR(100) NOT NULL, 
    [Name] VARCHAR(100) NOT NULL, 
    [ApplicationType] INT NOT NULL, 
    [Active] INT NOT NULL, 
    [RefreshTokenLifeTime] INT NOT NULL, 
    [AllowedOrigin] VARCHAR(MAX) NOT NULL
)