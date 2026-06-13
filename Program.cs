using System;
using Hotel.Modelos;

namespace Hotel.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel.Modelos.Hotel hotel = new Hotel.Modelos.Hotel();
            int opcion;

            do
            {
                Console.WriteLine("===== SISTEMA DE RESERVAS DE HOTEL =====");
                Console.WriteLine("1. Registrar nueva reserva");
                Console.WriteLine("2. Listar todas las reservas");
                Console.WriteLine("3. Calcular ingreso total");
                Console.WriteLine("4. Mostrar reserva de mayor duracion");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Reserva reserva = new Reserva();

                        Console.Write("Nombre del cliente: ");
                        reserva.Cliente = Console.ReadLine();

                        Console.Write("Numero de habitacion: ");
                        reserva.Habitacion = int.Parse(Console.ReadLine());

                        Console.Write("Fecha de ingreso: ");
                        reserva.FechaIngreso = DateTime.Parse(Console.ReadLine());

                        Console.Write("Numero de noches: ");
                        reserva.Noches = int.Parse(Console.ReadLine());

                        Console.Write("Precio por noche: ");
                        reserva.PrecioPorNoche = double.Parse(Console.ReadLine());

                        hotel.RegistrarReserva(reserva);

                        Console.WriteLine("Reserva registrada correctamente.");
                        break;

                    case 2:
                        hotel.ListarReservas();
                        break;

                    case 3:
                        Console.WriteLine("Ingreso total esperado: Q" + hotel.CalcularIngresoTotal());
                        break;

                    case 4:
                        hotel.MostrarReservaMayorDuracion();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != 5);
        }
    }
}