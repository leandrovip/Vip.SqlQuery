using Vip.SqlQuery.Enums;
using Xunit;

namespace Vip.SqlQuery.Tests.Clauses
{
    public class JoinTests
    {
        [Fact]
        public void Join_InnertJoin_Simple()
        {
            // Arrange
            var queryExpected = "SELECT * " +
                                "FROM [Produto] [p] " +
                                "INNER JOIN [Grupo] [g] ON [g].[GrupoId] = [p].[GrupoId]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .InnerJoin("Grupo g", "g.GrupoId", Condition.Equal, "p.GrupoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_InnertJoin_With_LeftJoin()
        {
            // Arrange
            var queryExpected = "SELECT * " +
                                "FROM [Produto] [p] " +
                                "INNER JOIN [Grupo] [g] ON [g].[GrupoId] = [p].[GrupoId] " +
                                "LEFT JOIN [Marca] [m] ON [m].[MarcaId] = [p].[MarcaId]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .InnerJoin("Grupo g", "g.GrupoId", Condition.Equal, "p.GrupoId")
                .LeftJoin("Marca m", "m.MarcaId", Condition.Equal, "p.MarcaId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_InnertJoin_With_LeftJoin_With_RightJoin()
        {
            // Arrange
            var queryExpected = "SELECT * " +
                                "FROM [Produto] [p] " +
                                "INNER JOIN [Grupo] [g] ON [g].[GrupoId] = [p].[GrupoId] " +
                                "LEFT JOIN [Marca] [m] ON [m].[MarcaId] = [p].[MarcaId] " +
                                "RIGHT JOIN [Categoria] [c] ON [c].[CategoriaId] = [p].[CategoriaId]";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .InnerJoin("Grupo g", "g.GrupoId", Condition.Equal, "p.GrupoId")
                .LeftJoin("Marca m", "m.MarcaId", Condition.Equal, "p.MarcaId")
                .RightJoin("Categoria c", "c.CategoriaId", Condition.Equal, "p.CategoriaId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_Custom_With_InnerJoin()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "INNER JOIN (SELECT TOP 1 * FROM GRUPO) g ON g.GrupoId = p.GrupoId";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .InnerJoin("(SELECT TOP 1 * FROM GRUPO) g ON g.GrupoId = p.GrupoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_Custom_With_InnerJoin_LeftJoin_RigthJoin()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "INNER JOIN (SELECT TOP 1 * FROM Grupo) g ON g.GrupoId = p.GrupoId " +
                                         "LEFT JOIN (SELECT TOP 1 * FROM Marca) m ON m.MarcaId = p.MarcaId " +
                                         "RIGHT JOIN (SELECT TOP 1 * FROM Tipo) t ON t.TipoId = p.TipoId";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .InnerJoin("(SELECT TOP 1 * FROM Grupo) g ON g.GrupoId = p.GrupoId")
                .LeftJoin("(SELECT TOP 1 * FROM Marca) m ON m.MarcaId = p.MarcaId")
                .RightJoin("(SELECT TOP 1 * FROM Tipo) t ON t.TipoId = p.TipoId")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_CrossApply_Simple()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "CROSS APPLY (Select * From Grupo g Where g.GrupoId = p.GrupoId) b";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .CrossApply("(Select * From Grupo g Where g.GrupoId = p.GrupoId) b")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }

        [Fact]
        public void Join_OuterApply_Simple()
        {
            // Arrange
            const string queryExpected = "SELECT * " +
                                         "FROM [Produto] [p] " +
                                         "OUTER APPLY (Select * From Grupo g Where g.GrupoId = p.GrupoId) b";

            // Act
            var query = SqlQuery.New()
                .Select()
                .From("Produto p")
                .OuterApply("(Select * From Grupo g Where g.GrupoId = p.GrupoId) b")
                .Build();

            // Assert
            Assert.Equal(queryExpected, query.Command);
        }
    }
}