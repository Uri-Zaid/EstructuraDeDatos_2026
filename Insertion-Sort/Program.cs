using System;

namespace EntregableFinal3
{
    // FASE 3 (Parte A):
    struct Transaccion 
    {     
        public int Id;            
        public double Monto;      
        public long Timestamp;    

        public Transaccion(int id, double monto, long timestamp)
        {         
            Id        = id;         
            Monto     = monto;         
            Timestamp = timestamp;     
        }

        public override string ToString()     
        {         
            return $"ID: {Id,4} | Monto: {Monto,10:F2} | Timestamp: {Timestamp}";     
        }
    }

    class Program
    {
        // FASE 3 (Parte B)
        static int OrdenarPorInsercion(Transaccion[] arr)
        {     
            int contadorDesplazamientos = 0;         
            int n = arr.Length;                   

            for (int i = 1; i < n; i++)               
            {
                Transaccion clave = arr[i];                
                int j = i - 1;                    

                while (j >= 0 && arr[j].Id > clave.Id)
                {             
                    arr[j + 1] = arr[j];                       
                    contadorDesplazamientos++;                 
                    j--;                                   
                }

                arr[j + 1] = clave;                    
            }

            return contadorDesplazamientos;       
        }

        // FASE 3 (Parte C)
        static void Main(string[] args) 
        {     
            try
            {         
                Transaccion[] bitacora = new Transaccion[45];         
                Random rng = new Random();
                
                // Prueba 1 (Mejor caso)
                for (int i = 0; i < 45; i++)
                {
                    bitacora[i] = new Transaccion(
                        id: i + 1, // IDs en perfecto orden ascendente (1, 2, 3...)
                        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + i * 100
                    );
                }

                // Prueba 2 (Peor caso)
                //for (int i = 0; i < 50; i++)
                //{
                //    bitacora[i] = new Transaccion(
                //       id: 50 - i, // IDs en orden descendente (50, 49, 48...)
                //        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                //        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + i * 100
                //    );
                //}
                
                //Prueba 3 (Prueba de Estabilidad)
                //for (int i = 0; i < 50; i++)
                //{
                //    bitacora[i] = new Transaccion(
                //        id: 999, // Todos comparten el mismo ID
                //       monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                //        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + i * 100
                //    );
                //}

                int[] idsAleatorios = { 78, 3, 99, 12, 55 };
                for (int i = 0; i < 5; i++)         
                {             
                    bitacora[45 + i] = new Transaccion(                 
                        id:        idsAleatorios[i],                 
                        monto:     Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (45 + i) * 100             
                    );         
                }

                Console.WriteLine("=== OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES ===\n");

                int totalDesplazamientos = OrdenarPorInsercion(bitacora);

                Console.WriteLine("Transacciones ordenadas por ID:");         
                foreach (var t in bitacora)             
                    Console.WriteLine(t);

                Console.WriteLine($"\nTotal de desplazamientos realizados: {totalDesplazamientos}");

                Console.WriteLine($"Eficiencia: {((1 - (double)totalDesplazamientos / (50 * 49 / 2)) * 100):F1}% mejor que el peor caso.");     
            }     
            catch (OverflowException ex)     
            {         
                Console.WriteLine($"[ERROR] Desbordamiento de datos: {ex.Message}");     
            }     
            catch (FormatException ex)     
            {         
                Console.WriteLine($"[ERROR] Formato de entrada inválido: {ex.Message}");     
            }     
            catch (Exception ex)     
            {
                Console.WriteLine($"[ERROR] Excepción inesperada: {ex.Message}");     
            } 
        }
    }
}