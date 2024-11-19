using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga4 : Enemy
{
    public Transform[] puntos;          // Arreglo de 4 puntos que el enemigo recorrerá
    public float velocidad = 2f;        // Velocidad de movimiento
    private int indiceActual = 0;       // Índice del punto actual

    // Start is called before the first frame update
    void Start()
    {
        if (puntos.Length > 0)
        {
            // Asegurarse de que el enemigo comience en el primer punto
            transform.position = puntos[0].position;
        }
        else
        {
            Debug.LogError("No se han asignado puntos al movimiento.");
        }
    }

    // Sobrescribe el método Update de la clase Enemy
    public override void Update()
    {
        base.Update(); // Llama a la lógica de la clase base (Enemy), si es necesaria
        Mover();
    }

    void Mover()
    {
        if (puntos.Length == 0) return; // Si no hay puntos, no hacer nada

        // Mover hacia el punto actual
        transform.position = Vector3.MoveTowards(transform.position, puntos[indiceActual].position, velocidad * Time.deltaTime);

        // Verificar si se ha alcanzado el punto actual
        if (Vector3.Distance(transform.position, puntos[indiceActual].position) < 0.1f)
        {
            // Pasar al siguiente punto
            indiceActual = (indiceActual + 1) % puntos.Length;
        }
    }
}
