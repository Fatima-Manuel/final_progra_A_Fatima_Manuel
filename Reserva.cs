using System;

namespace Hotel.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public int Habitacion { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int Noches { get; set; }

        public double PrecioPorNoche { get; set; }

        public double CalcularTotal()
        {
            return Noches * PrecioPorNoche;
        }
    }
}