using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga3 : Enemy
{
    public Transform puntoA;  // Punto inicial
    public Transform puntoB;  // Punto final
    public float velocidad = 3f; // Velocidad de movimiento

    private bool moviendoHaciaB = true;

    // Start is called before the first frame update
    void Start()
    {
        // La nave comienza en el punto A
        transform.position = puntoA.position;
    }

    // Sobreescribe el método Update de la clase Enemy
    public override void Update()
    {
        base.Update(); // Llama al Update de la clase base (Enemy) si tiene alguna funcionalidad adicional
        MoverEntrePuntos();
    }

    void MoverEntrePuntos()
    {
        // Determina el destino actual (punto A o punto B)
        Vector3 destino = moviendoHaciaB ? puntoB.position : puntoA.position;

        // Mueve la nave hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Cambia de dirección al llegar al destino
        if (transform.position == destino)
        {
            moviendoHaciaB = !moviendoHaciaB;  // Cambia entre A y B
            Debug.Log($"La nave se mueve de {(moviendoHaciaB ? "A" : "B")} a {(moviendoHaciaB ? "B" : "A")}");
        }
    }
}
