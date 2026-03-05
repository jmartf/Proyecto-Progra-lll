using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        public Rol Rol { get; set; }

        public EstadoUsuario Estado { get; set; }

        public ICollection<Cita> Citas { get; set; }

        public Usuario()
        {
            Citas = new List<Cita>();
        }
    }
}
