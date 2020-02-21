using Vip.SqlQuery.Enums;
using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class GroupByTests
    {
        [Fact]
        public void GroupBy_Simple()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId], [p].[Descricao] " +
                                         "FROM [Produto] [p] " +
                                         "LEFT JOIN [Grupo] [g] ON [g].[ProdutoId] = [p].[ProdutoId] " +
                                         "WHERE [p].[ProdutoId] = @p0 " +
                                         "GROUP BY [p].[ProdutoId]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] {"ProdutoId", "Descricao"}, "p")
                .From("Produto p")
                .LeftJoin("Grupo g", "g.ProdutoId", Condition.Equal, "p.ProdutoId")
                .Where("p.ProdutoId", Condition.Equal, 1)
                .GroupBy("p.ProdutoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void GroupBy_With_ManyColumns()
        {
            // Arrange
            const string queryExpected = "SELECT [p].[ProdutoId], [p].[Descricao], SUM(p.Valor) AS Valor " +
                                         "FROM [Produto] [p] " +
                                         "LEFT JOIN [Grupo] [g] ON [g].[ProdutoId] = [p].[ProdutoId] " +
                                         "WHERE [p].[ProdutoId] = @p0 " +
                                         "GROUP BY [p].[ProdutoId], [p].[Descricao]";

            // Act
            var query = SqlQuery.New()
                .Select(new[] { "ProdutoId", "Descricao" }, "p")
                .Select("SUM(p.Valor) as Valor")
                .From("Produto p")
                .LeftJoin("Grupo g", "g.ProdutoId", Condition.Equal, "p.ProdutoId")
                .Where("p.ProdutoId", Condition.Equal, 1)
                .GroupBy(new[] {"p.ProdutoId", "p.Descricao"})
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}