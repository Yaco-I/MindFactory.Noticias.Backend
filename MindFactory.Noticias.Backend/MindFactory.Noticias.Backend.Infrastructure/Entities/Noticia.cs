using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artifacts.EntityFramework;

namespace MindFactory.Noticias.Backend.Infrastructure.Entities;
public class Noticia: IAuditableEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; }
    [MaxLength(500)]
    public string URL { get; set; } 
    [Required]
    public string Contenido { get; set; } 
    [MaxLength(500)]
    public string Resumen { get; set; } 
    public bool Publicada { get; set; }
    public int CategoriaId { get; set; }

    public Categoria Categoria { get; set; }

    #region IAuditable
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int? DeletedBy { get; set; }
    #endregion IAuditable
}