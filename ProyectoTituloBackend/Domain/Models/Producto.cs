using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTituloBackend.Domain.Models
{
    public class Producto
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Descripcion { get; set; }

        [Required]
        public int Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int Activo { get; set; }
    }
}
