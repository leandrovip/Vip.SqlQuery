using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class OrderByTests
    {
        [Fact]
        public void OrderBy_Simple()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "ORDER BY [ProdutoId]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OrderBy("ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void OrderBy_DESC()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "ORDER BY [ProdutoId] DESC";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OrderByDesc("ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void OrderBy_ASC()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "ORDER BY [ProdutoId] ASC";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OrderByAsc("ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void OrderBy_More_Columns()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "ORDER BY [ProdutoId], [GrupoId]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OrderBy(new[] {"ProdutoId", "GrupoId"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void OrderBy_DESC_WithMoreColumns()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "ORDER BY [ProdutoId] DESC, [GrupoId], [p].[Descricao]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OrderByDesc("ProdutoId")
                .OrderBy(new[] {"GrupoId", "p.Descricao"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}