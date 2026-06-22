using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresa un número (35-43): ");
        string input = Console.ReadLine();

        // FASE 3 - MÓDULO C: Validación de entrada robusta
        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.WriteLine("Error: ingresa un número positivo.");
            return;
        }

        // Control opcional para evitar congelamientos excesivos en el método inseguro
        if (n > 45)
        {
            Console.WriteLine("Advertencia: Valores mayores a 45 pueden demorar demasiado en fuerza bruta.");
        }

        Stopwatch sw = new Stopwatch();

        // ========================================================
        //        MÓDULO A: Fibonacci Recursivo Tradicional
        // ========================================================
        Console.WriteLine("\n--- Ejecutando Método Inseguro (Fuerza Bruta) ---");
        sw.Restart();
        long r1 = FibonacciInseguro(n);
        sw.Stop();
        
        Console.WriteLine($"Inseguro: F({n}) = {r1}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");

        // ========================================================
        // MÓDULO B: Fibonacci con Memoization (Estrategia Pro)
        // ========================================================
        Console.WriteLine("\n--- Ejecutando Método Pro (Memoization) ---");
        
        // Inicialización del Caché (en Main)
        long[] cache = new long[n + 1];
        for (int i = 0; i <= n; i++)
        {
            cache[i] = -1;
        }

        sw.Restart();
        long r2 = FibonacciPro(n, cache);
        sw.Stop();

        Console.WriteLine($"Pro: F({n}) = {r2}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
        
        Console.WriteLine("\n------------------------------------------------");
        Console.WriteLine("¡Benchmark completado! Código listo para el Commit.");
    }

    // Módulo A: Implementación base no optimizada
    public static long FibonacciInseguro(int n)
    {
        if (n == 0) return 0; // Caso base 1
        if (n == 1) return 1; // Caso base 2
        
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    // Módulo B: Optimización industrial mediante Caché de Datos
    public static long FibonacciPro(int n, long[] cache)
    {
        if (n == 0) return 0; // Caso base 1
        if (n == 1) return 1; // Caso base 2

        // Verificación del Caché
        if (cache[n] != -1)
        {
            return cache[n]; 
        }

        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}