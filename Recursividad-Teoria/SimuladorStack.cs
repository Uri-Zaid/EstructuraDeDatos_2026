using System;

namespace EstructuraDatos
{
    public class SimuladorStack
    {
        // Ejercicio A
        public static void ImprimirCuentaRegresiva(int numero)
        {
            // CASO BASE
            if (numero < 1)
            {
                return;
            }

            // FASE DE APILADO
            Console.WriteLine($"[APILANDO] Llamada con {numero}");

            // CASO RECURSIVO
            ImprimirCuentaRegresiva(numero - 1);

            // FASE DE RETORNO
            Console.WriteLine($"[LIBERANDO] Marco con {numero}");
        }

        // Ejercicio B
        public static int SumarHasta(int n)
        {
            // CASO BASE
            if (n == 1)
            {
                return 1;
            }

            // CASO RECURSIVO
            return n + SumarHasta(n - 1);
        }
    }
}