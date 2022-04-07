using System.ComponentModel.DataAnnotations;

namespace Importaciones_SABS.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo codigo es obligatorio")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo Nombre del producto es obligatorio")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El campo Valor unitario es obligatorio")]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = "El campo Iva es obligatorio")]
        public  double Iva { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Fecha de resgistro es obligatorio")]
        public string FechaRegistro { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "El campo Categoria es obligatorio")]
        public int Id_categoria { get; set; }

    }
}
