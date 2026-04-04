using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Required]
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public Servicio? Servicio { get; set; }

        [Required]
        public string UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public EstadoCita Estado { get; set; }

    }
}
