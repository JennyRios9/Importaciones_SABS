using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]  
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Cedula es obligatorio")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public int Estado { get; set; }
        
        public int rol_id { get; set; }


    }
}
