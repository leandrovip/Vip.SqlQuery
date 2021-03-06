﻿using Vip.SqlQuery.Enums;
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
    }
}