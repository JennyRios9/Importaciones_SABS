using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la categoria es obligatorio")]
        public string NombreCategoria { get; set; }
    }
}
