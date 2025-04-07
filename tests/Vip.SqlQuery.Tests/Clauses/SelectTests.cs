using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class SelectTests
    {
        [Fact]
        public void Select_With_OneColumn()
        {
            // Arrange
            const string queryExpected = "SELECT [ProdutoId]";

            // Act
            var query = SqlQuery.New()
                .Select("ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_MoreColumns()
        {
            // Arrange
            const string queryExpected = "SELECT [ProdutoId], [Descricao], [Codigo]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao", "Codigo"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_TwoMetods()
        {
            // Arrange
            const string queryExpected = "SELECT [ProdutoId], [Descricao], [Codigo]";

            // Act
            var query = SqlQuery.New()
                .Select("ProdutoId")
                .Select(new[] {"Descricao", "Codigo"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Prefixe()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId]";

            // Act
            var query = SqlQuery.New()
                .Select("p.ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_TwoMetods_And_Prefix()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId], [p].[Descricao], [p].[Codigo]";

            // Act
            var query = SqlQuery.New()
                .Select("p.ProdutoId")
                .Select(new[] {"Descricao", "Codigo"}, "p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_More_Columns_With_Prefix()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId], [p].[Descricao], [p].[Codigo]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao", "Codigo"}, "p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Alias()
        {
            // Arrange
            const string queryExpected = "SELECT [ProdutoId] AS ProdutoId, [Descricao] AS NomeDoProduto";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId as ProdutoId", "Descricao As NomeDoProduto"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Alias_And_Prefix()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId] AS ProdutoId, [p].[Descricao] AS NomeDoProduto";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId as ProdutoId", "Descricao As NomeDoProduto"}, "p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Alias_Only_One_Column()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId] AS Codigo_Produto FROM [Produtos] [p]";

            // Act
            var query = SqlQuery.New()
                .Select("p.ProdutoId as Codigo_Produto")
                .From("Produtos p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_All_Methods()
        {
            // Arrange
            const string queryExpected =
                "SELECT [p].[ProdutoId], [p].[Codigo] AS Codigo_Barras, [p].[Descricao] FROM [Produtos] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Codigo as Codigo_Barras", "Descricao"}, "p")
                .From("Produtos p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Count()
        {
            // Arrange
            const string queryExpected = "SELECT COUNT(*) AS Registros FROM [Produtos]";

            // Act
            var query = SqlQuery.New()
                .Select("COUNT(*) as Registros")
                .From("Produtos")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_DatePart()
        {
            // Arrange
            const string queryExpected = "SELECT DATEPART(hour, p.Codigo) FROM [Produtos] [p] GROUP BY DATEPART(hour, p.Codigo)";

            // Act
            var query = SqlQuery.New()
                .Select("DATEPART(hour, p.Codigo)")
                .From("Produtos p")
                .GroupBy("DATEPART(hour, p.Codigo)")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Count_And_Column()
        {
            // Arrange
            const string queryExpected = "SELECT COUNT(*) AS Registros, [ProdutoId] FROM [Produtos]";

            // Act
            var query = SqlQuery.New()
                .Select("COUNT(*) as Registros")
                .Select("ProdutoId")
                .From("Produtos")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_Cast_And_column()
        {
            // Arrange
            const string queryExpected = "SELECT CAST(p.Data AS DATE) AS Data, [p].[Produto] FROM [Produtos] [p]";

            // Act
            var query = SqlQuery.New()
                .Select("CAST(p.Data as DATE) AS Data")
                .Select("p.Produto")
                .From("Produtos p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_CUSTOM()
        {
            // Arrange
            const string queryExpected = "SELECT TOP 1 v.ProdutoId AS Retorno, [p].[Produto] FROM [Produtos] [p]";

            // Act
            var query = SqlQuery.New()
                .Select("TOP 1 v.ProdutoId as Retorno")
                .Select("p.Produto")
                .From("Produtos p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Select_With_SubSelect()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[Codigo], [p].[Descricao], " +
                                         "(SELECT g.Grupo AS Grupo FROM Grupo g WHERE g.GrupoId = p.GrupoId) AS NomeGrupo " +
                                         "FROM [Produto] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"Codigo", "Descricao"}, "p")
                .Select("(SELECT g.Grupo as Grupo FROM Grupo g WHERE g.GrupoId = p.GrupoId) as NomeGrupo")
                .From("Produto p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}