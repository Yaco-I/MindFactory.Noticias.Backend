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
    @CategoriaId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT n.id, n.Titulo, n.URL, n.Contenido, n.Resumen, n.Publicada, n.CategoriaId, c.Nombre As CategoriaNombre
    FROM Noticias n
	JOIN Categorias c ON n.CategoriaId = n.id 
    WHERE (@Titulo IS NULL OR Titulo LIKE '%' + @Titulo + '%')
      AND (@Contenido IS NULL OR Contenido LIKE '%' + @Contenido + '%')
      AND (@Resumen IS NULL OR Resumen LIKE '%' + @Resumen + '%')
      AND (@CategoriaId IS NULL OR CategoriaId = @CategoriaId)
	  AND n.Publicada = 1 AND n.DeletedBy IS NULL;
END
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
