using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralelismo.Negocio
{
    public class Archivo
    {
        //Ejercicio con AppendAllLines and WriteAllLines
        //Lee las lineas de un archivo y las agrega a otro nuevo
        //AppendLines
        static readonly string datoRuta = @"C:\Users\Carolina Chamorro\source\repos\Paralelismo\fecha.txt";
        static void CrearArchivoSencillo()
        {
            DateTime tiempo = new DateTime(1990, 1, 1);
            using StreamWriter streamWriter = new StreamWriter(datoRuta);
            for (int i = 0; i < 300; i++)
            {
                DateTime Tiempo1 = tiempo.AddYears(i);
                DateTime Tiempo2 = Tiempo1.AddMonths(i);
                DateTime Tiempo3 = Tiempo2.AddDays(i);
                streamWriter.WriteLine(Tiempo3.ToLongDateString());
            }

        }
        public void AgregarLineas()
        {
            CrearArchivoSencillo();
            var AgostoFinSemana = from line in File.ReadLines(datoRuta)
                                  where (line.StartsWith("viernes") ||
                                  line.StartsWith("sábado") ||
                                  line.StartsWith("domingo")) &
                                  line.Contains("agosto")
                                  select line;
            File.WriteAllLines(@"C:\Users\Carolina Chamorro\source\repos\Paralelismo\dias.txt", AgostoFinSemana);
            var MarzoMiercoles = from line in File.ReadLines(datoRuta)
                                 where line.StartsWith("miércoles") &&
                                 line.Contains("marzo")
                                 select line;
            File.AppendAllLines(@"C:\Users\Carolina Chamorro\source\repos\Paralelismo\dias.txt", MarzoMiercoles);
        }

        

        //Ejemplo GetFiles
        public void TraerArchivos()
        {
            try
            {
                string[] files = Directory.GetFiles(@"C:\Users\Carolina Chamorro\Dropbox\Mi PC (laptop-caro)\Downloads", "a*");
                Console.WriteLine("El numero de archivos encontrados con la letra a son {0}.", files.Length);
                Parallel.ForEach(files, directorio =>
               {
                   Console.WriteLine(directorio);
               });
            }
            catch (Exception e)
            {
                Console.WriteLine("El proceso ha fallado: {0} .", e.ToString());
            }
        }

        public void AtraerDirectorios()
        {
            //Hacer directorio
            DirectoryInfo directorio = new DirectoryInfo(@"C:\\Users\Carolina Chamorro");
            //Hacer un array y traer todo los directorios
            DirectoryInfo[] directArray = directorio.GetDirectories();
            //Mostrar los nombres de los directorios
            foreach (DirectoryInfo directorios in directArray)
            {
                Console.WriteLine(directorios.Name);
            }
        }
        public void TraerUnidades()
        {
            DriveInfo[] todosLosDirectorios = DriveInfo.GetDrives();
            foreach (DriveInfo dir in todosLosDirectorios)
            {
               Console.WriteLine("Drive: {0}", dir.Name);
               Console.WriteLine("Drive tipo: {0}", dir.DriveType);
               if (dir.IsReady == true)
               {
                   Console.WriteLine("  Volumen: {0}", dir.VolumeLabel);
                   Console.WriteLine("   File Format: {0}", dir.DriveFormat);
                   Console.WriteLine(
                       "Espacio disponible para el usuario actual:{0,15} bytes"
                       , dir.AvailableFreeSpace);
                   Console.WriteLine(
                       "Espacio total disponible:                  {0,15} bytes"
                       , dir.TotalFreeSpace);
                   Console.WriteLine(
                       "Tamaño total de la unidad:                 {0,15} bytes"
                       , dir.TotalSize);
               }
           }
        }

    }
}
