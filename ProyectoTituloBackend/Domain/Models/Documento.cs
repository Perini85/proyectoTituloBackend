using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTituloBackend.Domain.Models
{
    public class Documento
    {


        public int Id { get; set; }

        public DateTime FechaCreacion { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Valor { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NumeroDoc { get; set; }

        public int IdCliente { get; set; }

        public Clientes Clientes { get; set; }

        public int TipoDocumentoId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }


        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int Activo { get; set; }


        public string Imagen { get; set; }


    }
}
