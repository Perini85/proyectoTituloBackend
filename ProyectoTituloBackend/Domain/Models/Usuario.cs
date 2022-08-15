using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTituloBackend.Domain.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public String nombreUsuario { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

    }
}
