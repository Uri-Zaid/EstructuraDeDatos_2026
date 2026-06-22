1. Sobre la estructura del árbol
       10
     /    \
    5      15
   / \    /  \
  3   7  12  20

    Altura: 2 (o 3 niveles de nodos)

2. Sobre la complejidad Big O
1
 \
  2
   \
    3
     \
      4
       \
        5
         \
          6
           \
            7

    ¿Por qué la búsqueda ya no es O(\log n)?
    La búsqueda deja de ser logarítmica porque el árbol ya no se bifurca

    Nombre del problema: Árbol degenerado

    Solución existente: Implementar estructuras auto-balanceadas (Árboles AVL, los Árboles Rojo-Negro (Red-Black Trees))

3. Sobre la recursión

    Caso Base: 
    Es la condición de salida de la función y su trabajo es detener la recursividad de golpe y devolver un valor sin generar más llamadas

    Caso Recursivo: 
    Es la sección donde el problema aún es muy grande y requiere dividirse

    Si se elimina el caso base, la función se volverá un bucle infinito de llamadas automáticas que nunca sabrá cuándo detenerse

    Error en tiempo de ejecución: StackOverflowException (Desbordamiento de la pila de memoria)

4. Sobre aplicaciones reales
    Escenario A:
    Los routers de internet necesitan redirigir millones de paquetes de datos por segundo mapeando IPs de destino a interfaces físicas
        Por qué marca la diferencia: A pesar de que una lista ordenada facilita que se realice la búsqueda binaria (O(log n)) rápidamente, las redes sufren cambios dinámicos. Se necesita mover físicamente miles de elementos en memoria (complejidad $O(n)$) para agregar o quitar una ruta en una lista ordenada. Un árbol binario equilibrado mantiene de manera constante las búsquedas, inserciones y eliminaciones en O(log n), lo que previene demoras en el tráfico total.
    
    Escenario B:
    En las plataformas de la bolsa de valores, las órdenes de compra y venta entran y se cancelan en milisegundos y el sistema necesita encontrar instantáneamente la mejor oferta disponible
        Por qué marca la diferencia: Con millones de usuarios compitiendo, meter una nueva oferta en una lista ordenada haría que el sistema colapse por el costo de reordenamiento (O(n)). El rendimiento de O(\log n) en un árbol balanceado garantiza que tanto buscar la oferta más alta como insertar una nueva tome apenas una veintena de pasos lógicos , permitiendo transacciones instantáneas sin importar el volumen de datos