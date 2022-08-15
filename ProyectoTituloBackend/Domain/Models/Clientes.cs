using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTituloBackend.Domain.Models
{
    public class Clientes
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombres { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Apellidos { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Rut { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Correo { get; set; }


        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Telefono { get; set; }


        public int Activo { get; set; }

        public List<Documento> ListDocumentos { get; set; }

    }
}
