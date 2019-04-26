using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class LimitTests
    {
        [Fact]
        public void Limit_10_Rows()
        {
            // Arrange
            var queryExpected = "SELECT TOP 10 [p].[ProdutoId], [p].[Descricao] FROM [Produto] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"}, "p")
                .From("Produto p")
                .Limit(10)
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Limit_0_Rows()
        {
            // Arrange
            var queryExpected = "SELECT TOP 500 [p].[ProdutoId], [p].[Descricao] FROM [Produto] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"}, "p")
                .From("Produto p")
                .Limit(0)
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Limit_20_Rows_With_Percent()
        {
            // Arrange
            var queryExpected = "SELECT TOP 20 PERCENT [p].[ProdutoId], [p].[Descricao] FROM [Produto] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"}, "p")
                .From("Produto p")
                .Limit(20, true)
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}