using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Clientes
    {
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio")]
        public string Fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo Direccion  es obligatorio")]
        public string Direccion { get; set; }
      

    }
}
