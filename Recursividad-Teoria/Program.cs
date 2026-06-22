using System;

namespace EstructuraDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ejercicio A: Cuenta Regresiva de Memoria ===");
            SimuladorStack.ImprimirCuentaRegresiva(3);
            Console.WriteLine("¡Despegue!\n");

            Console.WriteLine("=== Ejercicio B: Sumatoria Recursiva ===");
            Validador.EjecutarSumatoria();
        }
    }
}