using System;

namespace EstructuraDatos
{
    public class Validador
    {
        public static void EjecutarSumatoria()
        {
            Console.Write("Introduce un número positivo: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero) && numero > 0)
            {
                int resultado = SimuladorStack.SumarHasta(numero);
                Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se aceptan enteros positivos.");
                Console.ResetColor();
            }
        }
    }
}