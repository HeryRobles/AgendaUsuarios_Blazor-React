using System.ComponentModel.DataAnnotations;

namespace AgendaUsuarios.Model.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        public string Telefono { get; set; }
    }
}
