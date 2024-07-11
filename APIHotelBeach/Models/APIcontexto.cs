using Microsoft.EntityFrameworkCore;

namespace APIHotelBeach.Models
{
    public class APIcontexto: DbContext
    {
        public APIcontexto(DbContextOptions<APIcontexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente  { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
        public DbSet<Reservacion> Reservacion  { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(new Cliente()
            {
                IdCliente = 1,
                TipoCedula = "Juridica",
                Cedula = "504420978",
                NombreCompleto = "Luis",
                Telefono = 222222,
                Direccion = "hhh",
                CorreoElectronico = "ejemplo@gmail.com"

            });

            modelBuilder.Entity<Paquete>().HasData(new Paquete()
            {
                IdPaquete = 1,
                NombrePaquete = "Todo Incluido",
                Precio = 450,
                ProcentajePrima = 0.45,
                NumMensualidades = 24
            });

            
        }

    }
}
