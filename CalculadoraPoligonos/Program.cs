using System;

class Program
{
    static void Main(string[] args)
    {
        int cantidadLados = SeleccionarPoligono();
        Console.WriteLine(); 

        (double medidaLado, double medidaApotema) = PedirDatos();

        double areaFinal = CalcularArea(cantidadLados, medidaLado, medidaApotema);

        Console.WriteLine("\n====================================");
        Console.WriteLine($"El área del polígono de {cantidadLados} lados es: {areaFinal:F2}");
        Console.WriteLine("====================================");
        
        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine(); 
    }

static int SeleccionarPoligono()
{
    // Menu
    Console.WriteLine("====================================");
    Console.WriteLine("     Calculadora de Polígonos       ");
    Console.WriteLine("====================================");
    Console.WriteLine("1. Pentágono (5 lados)");
    Console.WriteLine("2. Hexágono (6 lados)");
    Console.WriteLine("3. Heptágono (7 lados)");
    Console.WriteLine("4. Octágono (8 lados)");
    Console.Write("Elige una opción (1-4): ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            return 5; 
        case "2":
            return 6; 
        case "3":
            return 7; 
        case "4":
            return 8; 
        default:
            Console.WriteLine("\nOpción no válida. Se seleccionará Pentágono (5 lados) por defecto.");
            return 5;
    }
}

static (double longitud, double apotema) PedirDatos()
{
    Console.Write("Ingresa la longitud de un lado del polígono: ");
    double longitud = double.Parse(Console.ReadLine());
    Console.Write("Ingresa la longitud de un lado de la apotema: ");
    double apotema = double.Parse(Console.ReadLine());
    return (longitud, apotema);
}

static double CalcularArea(int lados, double longitud, double apotema)
{
    return (lados * longitud * apotema) / 2;
}
}