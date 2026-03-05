using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(300)]
        public string Descripcion { get; set; }

        [Required]
        [Range(1, 600)]
        public int DuracionMinutos { get; set; }

        [Required]
        [Range(0.01, 999999)]
        public decimal Costo { get; set; }

        [Required]
        public EstadoServicio Estado { get; set; }

        public ICollection<Cita> Citas { get; set; }

        public Servicio()
        {
            Citas = new List<Cita>();
        }
    }
}
