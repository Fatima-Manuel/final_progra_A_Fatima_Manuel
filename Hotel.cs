using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Hotel.Modelos
{
    public class Hotel
    {
        private string conexion = @"Server=(localdb)\MSSQLLocalDB;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void RegistrarReserva(Reserva reserva)
        {
            using (var db = new SqlConnection(conexion))
            {
                string sql = @"INSERT INTO Reservas
                (Cliente, Habitacion, FechaIngreso, Noches, PrecioPorNoche)
                VALUES
                (@Cliente, @Habitacion, @FechaIngreso, @Noches, @PrecioPorNoche)";

                db.Execute(sql, reserva);
            }
        }

        public void ListarReservas()
        {
            using (var db = new SqlConnection(conexion))
            {
                string sql = "SELECT * FROM Reservas";
                List<Reserva> reservas = db.Query<Reserva>(sql).AsList();

                if (reservas.Count == 0)
                {
                    Console.WriteLine("No hay reservas registradas.");
                }

                foreach (Reserva reserva in reservas)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Cliente: " + reserva.Cliente);
                    Console.WriteLine("Habitacion: " + reserva.Habitacion);
                    Console.WriteLine("Fecha de ingreso: " + reserva.FechaIngreso.ToShortDateString());
                    Console.WriteLine("Noches: " + reserva.Noches);
                    Console.WriteLine("Precio por noche: Q" + reserva.PrecioPorNoche);
                    Console.WriteLine("Total: Q" + reserva.CalcularTotal());
                }
            }
        }

        public double CalcularIngresoTotal()
        {
            using (var db = new SqlConnection(conexion))
            {
                string sql = "SELECT ISNULL(SUM(Noches * PrecioPorNoche), 0) FROM Reservas";
                return db.QueryFirst<double>(sql);
            }
        }

        public void MostrarReservaMayorDuracion()
        {
            using (var db = new SqlConnection(conexion))
            {
                string sql = "SELECT TOP 1 * FROM Reservas ORDER BY Noches DESC";
                Reserva mayor = db.QueryFirstOrDefault<Reserva>(sql);

                if (mayor == null)
                {
                    Console.WriteLine("No hay reservas registradas.");
                }
                else
                {
                    Console.WriteLine("Reserva de mayor duracion:");
                    Console.WriteLine("Cliente: " + mayor.Cliente);
                    Console.WriteLine("Habitacion: " + mayor.Habitacion);
                    Console.WriteLine("Noches: " + mayor.Noches);
                    Console.WriteLine("Total: Q" + mayor.CalcularTotal());
                }
            }
        }
    }
}