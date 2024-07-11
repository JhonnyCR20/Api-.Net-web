using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APIHotelBeach.Models
{
    public class Reservacion
    {
        public Reservacion()
        {
            Impuesto = 0.13;
        }

        [Key]
        public int idReservacion { get; set; }

        [Required]
        public string? NombreCliente { get; set; }

        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadNoches { get; set; }
        public int CantidadPersonas { get; set; }
        public string? FormaPago { get; set; }

        public double Precio { get; set; }
        public string? PaqueteEscogido { get; set; }

        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Impuesto { get; }
        public double MontoTotal { get; set; }
        public double Prima { get; set; }

        public double PagoMensual { get; set; }
        
    }
}
