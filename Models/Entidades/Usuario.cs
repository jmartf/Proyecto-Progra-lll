using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;


namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

        public EstadoUsuario Estado { get; set; }

        public ICollection<Cita> Citas { get; set; }

        public Usuario()
        {
            Citas = new List<Cita>();
        }
    }
}
