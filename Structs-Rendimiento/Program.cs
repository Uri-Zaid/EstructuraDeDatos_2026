using System;

namespace TelemetriaGPS
{
    class Program
    {
        static void Main(string[] args)
        {
            // ====================================================================
            // MÓDULO B: COMPROBANDO LA COPIA POR VALOR (STACK)
            // ====================================================================
            Console.WriteLine("=== MÓDULO B: Experimento de Copia por Valor ===");

            // 1. Instanciamos la Ciudad de México en c1
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);

            // 2. Copia por valor en el Stack (entidades completamente independientes)
            CoordenadaGPS c2 = c1;

            // 3. Reasignamos c2 para que apunte a Berlín
            c2 = new CoordenadaGPS(52.5200, 13.4050);

            // 4. Imprimimos ambas para demostrar que modificar c2 no alteró a c1
            Console.WriteLine("--- c1 (Ciudad de México Esperada) ---");
            c1.ImprimirUbicacion();

            Console.WriteLine("--- c2 (Berlín Esperado) ---");
            c2.ImprimirUbicacion();
            
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // ====================================================================
            // MÓDULO C: CONTROL DE EXCEPCIONES Y ROBUSTEZ
            // ====================================================================
            Console.WriteLine("=== MÓDULO C: Captura de Datos con Validación ===");
            
            try
            {
                // Lectura de datos desde la consola
                Console.Write("Introduce la Latitud [-90, 90]: ");
                double lat = double.Parse(Console.ReadLine());

                Console.Write("Introduce la Longitud [-180, 180]: ");
                double lon = double.Parse(Console.ReadLine());

                // Intento de instanciación (Disparará la validación del constructor)
                CoordenadaGPS coordUsuario = new CoordenadaGPS(lat, lon);

                Console.WriteLine("\n[ÉXITO] Coordenada creada correctamente:");
                coordUsuario.ImprimirUbicacion();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Captura específica de rangos geográficos incorrectos
                Console.WriteLine($"\n[ERROR DE VALIDACIÓN] {ex.Message}");
            }
            catch (FormatException)
            {
                // Captura opcional por si el usuario introduce texto en lugar de números
                Console.WriteLine("\n[ERROR DE FORMATO] Por favor, introduce un número decimal válido.");
            }
        }
    }

    public readonly struct CoordenadaGPS
    {
        public double Latitud { get; }
        public double Longitud { get; }

        // Constructor con validación de rangos reales de la Tierra
        public CoordenadaGPS(double lat, double lon)
        {
            // Validación para la Latitud [-90, 90]
            if (lat < -90 || lat > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(lat), "Latitud fuera de rango [-90, 90]");
            }

            // Validación para la Longitud [-180, 180]
            if (lon < -180 || lon > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(lon), "Longitud fuera de rango [-180, 180]");
            }

            Latitud = lat;
            Longitud = lon;
        }

        // Método para exponer la ubicación formateada
        public void ImprimirUbicacion()
        {
            Console.WriteLine($"Ubicación -> Latitud: {Latitud}, Longitud: {Longitud}");
        }
    }
}