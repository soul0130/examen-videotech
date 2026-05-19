using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; // Requis pour interagir con MySQL

namespace VideoTech
{
    public class GestorBD
    {
        private string cadenaConexion;

        // Apartado 3.1 - Conexión
        public GestorBD()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = ""; // Sin contraseña según el enunciado
            builder.Database = "videotech";

            cadenaConexion = builder.ConnectionString;
        }

        // Apartado 3.2 - Insertar
        public void Insertar(Pelicula p)
        {
            string query = "INSERT INTO pelicula (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible);";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    // Uso de AddWithValue para proteger los parámetros contra inyecciones SQL
                    comando.Parameters.AddWithValue("@titulo", p.GetTitulo());
                    comando.Parameters.AddWithValue("@director", p.GetDirector());
                    comando.Parameters.AddWithValue("@anyo", p.GetAnyo());
                    comando.Parameters.AddWithValue("@disponible", p.IsDisponible());

                    conexion.Open();
                    comando.ExecuteNonQuery(); // Ejecuta la inserción
                }
            }
        }

        // Apartado 3.3 - Leer todos
        public List<Pelicula> ObtenerTodos()
        {
            List<Pelicula> lista = new List<Pelicula>();
            string query = "SELECT * FROM pelicula;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader()) // Uso de ExecuteReader
                    {
                        while (reader.Read())
                        {
                            string titulo = reader["titulo"].ToString();
                            string director = reader["director"].ToString();
                            int anyo = Convert.ToInt32(reader["anyo"]);
                            bool disponible = Convert.ToBoolean(reader["disponible"]);

                            Pelicula p = new Pelicula(titulo, director, anyo, disponible);
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }
    }
}