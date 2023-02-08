using Npgsql;
using System.Xml.Linq;

namespace SubirImagenesAbbdd.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
       public static void insertarImagen(IConfiguration _config,string imgCode)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("EFCConexion"));
            Console.WriteLine("HABRIENDO CONEXION");
            connection.Open();
            Console.WriteLine("HACIENDO CONSULTA");
            NpgsqlCommand consulta = new NpgsqlCommand($"INSERT INTO \"imagenes\".\"imagenes\" (imagen_code) VALUES('{imgCode}')", connection);
            Console.WriteLine("CERRANDO CONEXION");
            connection.Close();
        }
    }
}
