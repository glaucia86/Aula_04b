CREATE TABLE [dbo].[Produto]
(
	[Codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Descricao] NVARCHAR(MAX) NOT NULL, 
    [Preco] DECIMAL(18, 2) NOT NULL, 
    [Quantidade_Estoque] INT NOT NULL, 
    [Data_Cadastro] DATETIME NOT NULL
)
