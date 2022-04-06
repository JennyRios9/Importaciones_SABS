using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Rol    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo rol es obligatorio")]  
        public string Nombre { get; set; }

    }
}
