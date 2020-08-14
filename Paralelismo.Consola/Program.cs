using System;
using Paralelismo.Negocio;

namespace Paralelismo.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var archivo = new Archivo();
            
            Console.WriteLine("AppendLines-WriteAllLines-Lee las lineas de un archivo y las agrega a otro nuevo.");
            Console.WriteLine("Ejercicio Secuencial con For/ ,mirar los archivos dias/fecha");
            archivo.AgregarLineas();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Ejercicio con Parallel.Foreach--Traer archivos");
            archivo.TraerArchivos();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Ejercicio con Secuenciasl con Foreach--Traer directorios");
            archivo.AtraerDirectorios();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Ejercicio con Secuencial Foreach--Traer unidades");
            archivo.TraerUnidades();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Hilos de procesos en nuestras máquinas");
            var hilo = new Hilo();
            hilo.VerHilos();
        }
    }
}
