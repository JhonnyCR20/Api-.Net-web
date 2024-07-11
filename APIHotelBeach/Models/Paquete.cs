using System.ComponentModel.DataAnnotations;

namespace APIHotelBeach.Models
{
    public class Paquete
    {
        [Key]
        public int IdPaquete { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del paquete")]
        public string NombrePaquete { get; set; } = null!;

        public double Precio { get; set; }
        public double ProcentajePrima { get; set; }
        public int NumMensualidades { get; set; }
    }
}
