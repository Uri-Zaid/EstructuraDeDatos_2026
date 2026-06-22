using System;

namespace Entregable6
{
    // Módulo 3: Clase Alumno
    class Alumno
    {
        public string Nombre { get; set; }
    }

    class Program
    {
        // Módulo 1: El Modificador ref en Acción
        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Módulo 2: El Modificador out
        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            residuo = dividendo % divisor;
            return dividendo / divisor;
        }

        static void Main()
        {
            Console.WriteLine("=== Módulo 1: Modificador ref ===");
            int x = 10, y = 25;
            Console.WriteLine($"Antes: x={x}, y={y}");
            Intercambiar(ref x, ref y);
            Console.WriteLine($"Después: x={x}, y={y}\n");

            Console.WriteLine("=== Módulo 2: Modificador out ===");
            int cociente = CalcularYValidar(17, 5, out int resto);
            Console.WriteLine($"Cociente: {cociente}");
            Console.WriteLine($"Residuo: {resto}\n");

            Console.WriteLine("=== Módulo 3: Referencias de Objetos ===");
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            Alumno alumno2 = alumno1;
            
            Console.WriteLine($"Nombre original de alumno1: {alumno1.Nombre}");
            alumno2.Nombre = "3Treum";
            Console.WriteLine($"Cambiando el nombre en alumno2 a '3Treum'...");
            Console.WriteLine($"Nombre resultante en alumno1: {alumno1.Nombre}");
            // Imprime 3Treum porque ambas variables apuntan a la misma dirección en el Heap.
        }
    }
}