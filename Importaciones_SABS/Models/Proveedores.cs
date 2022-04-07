using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Proveedores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre de la empresa es obligatorio")]  
        public string Nombre_empresa { get; set; }

        [Required(ErrorMessage = "El campo Dirección de la empresa es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Telefono  de la empresa es obligatorio")]
        public string Telefono_empresa { get; set; }

        [Required(ErrorMessage = "El campo Correo de la empresa es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Nombre del representante legal es obligatorio")]
        public string Nombre_representante_legal { get; set; }

        [Required(ErrorMessage = "El campo Telefono del representante legal es obligatorio")]
        public string Telefono_representante { get; set; }
    }
}
