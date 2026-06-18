using System;

public class Nodo
{
    public int ID { get; set; }
    public string Dato { get; set; } = string.Empty;

    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Construyendo el Árbol Binario de Búsqueda (BST) ===");

        var raiz = new Nodo(5, "Raíz");
        raiz = InsertarNodo(raiz, new Nodo(3, "Izquierda"));
        raiz = InsertarNodo(raiz, new Nodo(7, "Derecha"));

        Console.WriteLine("\n=== Verificando Búsquedas ===");

        string? resultado = BuscarNodo(raiz, 3);
        Console.WriteLine($"Buscando ID 3: {resultado ?? "No encontrado"}");

        string? resultadoDos = BuscarNodo(raiz, 7);
        Console.WriteLine($"Buscando ID 7: {resultadoDos ?? "No encontrado"}");

        string? resultadoFalso = BuscarNodo(raiz, 15);
        Console.WriteLine($"Buscando ID 15: {resultadoFalso ?? "No encontrado"}");
    }
    
    public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        if (raiz == null)
            return nuevoNodo;

        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
        }

        return raiz;
    }

    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        if (raiz == null)
            return null;

        if (idTarget == raiz.ID)
            return raiz.Dato;

        if (idTarget < raiz.ID)
        {
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);
        }
        else
        {
            return BuscarNodo(raiz.HijoDerecho, idTarget);
        }
    }
}