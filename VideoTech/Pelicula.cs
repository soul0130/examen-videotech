using System;

namespace VideoTech
{
    public class Pelicula
    {
        // Los cuatro atributos privados (Apartado 1.2)
        private string titulo;
        private string director;
        private int anyo;
        private bool disponible;

        // El constructor con sus cuatro parámetros (usa 'this.' para asignarlos) (Apartado 1.2)
        public Pelicula(string titulo, string director, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.director = director;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        // Propiedades públicas / Métodos get para cada atributo (Apartado 1.2)
        public string GetTitulo() { return this.titulo; }
        public string GetDirector() { return this.director; }
        public int GetAnyo() { return this.anyo; }
        public bool IsDisponible() { return this.disponible; }

        // El método ToString() que devuelve: "Titulo - Director (Anyo)" (Apartado 1.2)
        public override string ToString()
        {
            return $"{this.titulo} - {this.director} ({this.anyo})";
        }
    }
}