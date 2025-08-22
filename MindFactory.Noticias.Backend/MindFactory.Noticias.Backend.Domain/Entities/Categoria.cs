using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artifacts.EntityFramework;

namespace MindFactory.Noticias.Backend.Infrastructure.Entities;

[Table("Categoria")]
public class Categoria : IAuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(100)]
    public string Slug { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();


    #region IAuditable
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int? DeletedBy { get; set; }
    #endregion IAuditable
}
