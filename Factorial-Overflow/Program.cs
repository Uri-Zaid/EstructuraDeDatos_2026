using System;
using System.Numerics;

namespace EstructuraDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Análisis de Factorial: Iterativo vs Recursivo ===");

            // El Ciclo de Diagnóstico en Main
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"n={i:D2} | Recursivo: {FactorialInt(i),25} | Iterativo: {FactorialIterativo(i),25}");
            }

            Console.WriteLine("\n=== Refactorización Profesional con BigInteger ===");
            
            // Prueba con n = 100
            BigInteger resultado = FactorialProfesional(100);
            Console.WriteLine($"100! = {resultado}");
        }

        // Función Recursiva - FactorialInt
        static int FactorialInt(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * FactorialInt(n - 1);
        }

        // Función Iterativa - FactorialIterativo
        static int FactorialIterativo(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        /*
         El desbordamiento aritmético ocurre exactamente a partir de n = 13.
         13!: 6,227,020,800
         Límite máximo de un tipo int de 32 bits: 2,147,483,647.
         */

        // Implementación de Alta Precisión
        static BigInteger FactorialProfesional(BigInteger n)
        {
            // Caso Base
            if (n == 0 || n == 1)
            {
                return BigInteger.One;
            }
            
            // Caso Recursivo
            return n * FactorialProfesional(n - 1);
        }
    }
}