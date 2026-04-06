using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public int? ClienteId { get; set; }
        [ValidateNever]
        public Cliente Cliente { get; set; }

        [Required]
        public int? ServicioId { get; set; }
        [ValidateNever]
        public Servicio Servicio { get; set; }

        [Required]
        public int? UsuarioId { get; set; }
        [ValidateNever]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public EstadoCita Estado { get; set; }
    }
}
