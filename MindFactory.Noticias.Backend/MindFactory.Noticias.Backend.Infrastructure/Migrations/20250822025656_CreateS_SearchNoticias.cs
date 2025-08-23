using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindFactory.Noticias.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateS_SearchNoticias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" 
            CREATE PROCEDURE [dbo].[S_SearchNoticias]
                    @Titulo NVARCHAR(200) = NULL,
                    @Contenido NVARCHAR(MAX) = NULL,
                    @Resumen NVARCHAR(500) = NULL,
                    @CategoriaId INT = NULL,
                    @PageNumber INT = NULL,
                    @PageSize INT = NULL,
                    @TotalNumberRows BIGINT OUTPUT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT @TotalNumberRows = COUNT(*)
                    FROM Noticias n
                    JOIN Categorias c ON n.CategoriaId = c.Id
                    WHERE (@Titulo IS NULL OR n.Titulo LIKE '%' + @Titulo + '%')
                      AND (@Contenido IS NULL OR n.Contenido LIKE '%' + @Contenido + '%')
                      AND (@Resumen IS NULL OR n.Resumen LIKE '%' + @Resumen + '%')
                      AND (@CategoriaId IS NULL OR n.CategoriaId = @CategoriaId)
                      AND n.Publicada = 1
                      AND n.DeletedBy IS NULL;

                    DECLARE @sql NVARCHAR(MAX) = N'
                    SELECT n.id, n.Titulo, n.URL, n.Contenido, n.Resumen, n.Publicada, n.CategoriaId, c.Nombre AS CategoriaNombre
                    FROM Noticias n
                    JOIN Categorias c ON n.CategoriaId = c.Id
                    WHERE (@Titulo IS NULL OR n.Titulo LIKE ''%'' + @Titulo + ''%'')
                      AND (@Contenido IS NULL OR n.Contenido LIKE ''%'' + @Contenido + ''%'')
                      AND (@Resumen IS NULL OR n.Resumen LIKE ''%'' + @Resumen + ''%'')
                      AND (@CategoriaId IS NULL OR n.CategoriaId = @CategoriaId)
                      AND n.Publicada = 1
                      AND n.DeletedBy IS NULL
                    ';

                    IF (@PageNumber IS NOT NULL AND @PageSize IS NOT NULL)
                    BEGIN
                        SET @sql = @sql + N'
                        ORDER BY n.Id DESC
                        OFFSET @Offset ROWS
                        FETCH NEXT @PageSize ROWS ONLY
                        ';
                    END

                    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

                    EXEC sp_executesql
                        @sql,
                        N'@Titulo NVARCHAR(200), @Contenido NVARCHAR(MAX), @Resumen NVARCHAR(500), @CategoriaId INT, @PageSize INT, @Offset INT',
                        @Titulo=@Titulo, @Contenido=@Contenido, @Resumen=@Resumen, @CategoriaId=@CategoriaId,
                        @PageSize=@PageSize, @Offset=@Offset;
            END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[S_SearchNoticias]");
        }
    }
}
