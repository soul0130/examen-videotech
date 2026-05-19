using System;
using System.Collections.Generic;
using System.IO;

namespace VideoTech
{
    class Program
    {
        static void Main(string[] args)
        {

            //Apartado 2.1 - Trabajar con la lista

            // a) Crea una List<Pelicula> e inserta tres películas con Add()
            List<Pelicula> listaPeliculas = new List<Pelicula>();
            listaPeliculas.Add(new Pelicula("Interstellar", "Christopher Nolan", 2014, true));
            listaPeliculas.Add(new Pelicula("El Padrino", "Francis Ford Coppola", 1972, false));
            listaPeliculas.Add(new Pelicula("Origen", "Christopher Nolan", 2010, true));

            // b) Muestra por consola todas las películas con un foreach y ToString()
            Console.WriteLine("--- TODAS LAS PELÍCULAS ---");
            foreach (Pelicula pelicula in listaPeliculas)
            {
                Console.WriteLine(pelicula.ToString());
            }
            Console.WriteLine();

            // c) Recorre la lista y muestra solo las películas cuyo director contenga "Nolan"
            Console.WriteLine("--- PELÍCULAS DE CHRISTOPHER NOLAN ---");
            foreach (Pelicula pelicula in listaPeliculas)
            {
                if (pelicula.GetDirector().Contains("Nolan"))
                {
                    Console.WriteLine(pelicula.ToString());
                }
            }
            Console.WriteLine();

            
            // Apartado 2.2 - Fecha de registro
            
            // Muestra por consola la fecha actual en formato corto
            Console.WriteLine("Fecha actual de registro:");
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine();

            
            // Apartado 2.3 - Guardar en fichero
            
            string rutaFichero = "peliculas.txt";
            GuardarPeliculas(listaPeliculas, rutaFichero);
            Console.WriteLine($"Fichero guardado correctamente.");

            // Pausa para que la consola no se cierre inmediatamente al ejecutar
            Console.ReadLine();
        }

        // Método que guarda todas las películas en un fichero de texto, una por línea
        public static void GuardarPeliculas(List<Pelicula> lista, string ruta)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (Pelicula p in lista)
                {
                    // Formato esperado: Titulo; Director; Anyo; Disponible
                    string linea = $"{p.GetTitulo()};{p.GetDirector()};{p.GetAnyo()};{p.IsDisponible()}";
                    sw.WriteLine(linea);
                }
            }
        }
    }
}
