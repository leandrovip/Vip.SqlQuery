using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class FromTests
    {
        [Fact]
        public void From_With_Select()
        {
            // Arrange
            var queryExpected = "SELECT [ProdutoId], [Descricao], [Codigo] FROM [Produto]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"})
                .From("Produto")
                .Select("Codigo")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void From_With_Prefix()
        {
            // Arrange
            const string queryExpected = "SELECT [ProdutoId], [Descricao] FROM [Produto] [p]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"})
                .From("Produto p")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}