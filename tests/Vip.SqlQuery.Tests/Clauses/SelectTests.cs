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
    }
}