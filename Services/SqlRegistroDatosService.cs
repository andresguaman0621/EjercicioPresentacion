using EjercicioPresentacion.Models;
using System;
using System.Data;
using System.Data.SqlClient;


namespace EjercicioPresentacion.Services
{
    public class SqlRegistroDatosService : IRegistroDatosService
    {
        private readonly string _connectionString;

        public SqlRegistroDatosService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RegistrarDatos(RegistroDatos datos)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO RegistroDatos (Nombre, Email) VALUES (@Nombre, @Email)", connection);
                    command.Parameters.AddWithValue("@Nombre", datos.Nombre);
                    command.Parameters.AddWithValue("@Email", datos.Email);
                    // Agregar otros parámetros según la estructura de tu base de datos y modelo

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error al registrar datos: " + ex.Message);
                    throw; // Opcional: relanzar la excepción para manejarla en otro lugar
                }
            }
        }
    }
}
