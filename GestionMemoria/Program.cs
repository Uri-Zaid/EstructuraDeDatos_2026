using System;

class Program
{
    static void Main(string[] args)
    {
        int miValor = 10;
        int[] miArreglo = {10, 20, 30};

        Console.WriteLine("=== Antes de modificar ===");
        Console.WriteLine($"Valor inicial de miValor: {miValor}");
        Console.WriteLine($"Primer elemento de miArreglo: {miArreglo[0]}");

        CambiarValor(miValor);
        CambiarArreglo(miArreglo); 

        Console.WriteLine("=== Después de modificar ===");
        Console.WriteLine($"Valor de miValor después de cambiar: {miValor}");
        Console.WriteLine($"Primer elemento de miArreglo después de cambiar: {miArreglo[0]}");

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();

    }

    static void CambiarValor(int valor)
    {
        valor = 100; 
    }

    static void CambiarArreglo(int[] arreglo)
    {
        arreglo[0] = 100; 
    }
}