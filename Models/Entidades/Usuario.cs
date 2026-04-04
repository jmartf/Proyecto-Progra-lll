using Microsoft.AspNetCore.Identity;
using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.ComponentModel.DataAnnotations;


namespace Proyecto_Programacion_III.Models.Entidades
{
    public class Usuario : IdentityUser
    {


        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public EstadoUsuario Estado { get; set; }

        public ICollection<Cita> Citas { get; set; }

        public Usuario()
        {
            Citas = new List<Cita>();
        }
    }
}
