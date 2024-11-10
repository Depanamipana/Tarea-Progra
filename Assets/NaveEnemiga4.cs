using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga4 : Enemy
{
    public Transform puntoA;  // Punto de inicio (izquierda)
    public Transform puntoB;  // Punto de destino (derecha)
    public float velocidadHorizontal = 2f; // Velocidad de movimiento entre puntos A y B
    public float velocidadDescenso = 1f;   // Velocidad de descenso

    private bool moviendoHaciaB = true;    // Direccion inicial, hacia el punto B

    // Start is called before the first frame update
    void Start()
    {
        // La nave comienza en el punto A
        transform.position = puntoA.position;
    }

    // Sobrescribe el método Update de la clase Enemy
    public override void Update()
    {
        base.Update(); // Llama a la lógica de la clase base (Enemy), si es necesaria
        Mover();
    }

    void Mover()
    {
        // Movimiento horizontal entre A y B
        Vector3 destinoHorizontal = moviendoHaciaB ? puntoB.position : puntoA.position;
        transform.position = Vector3.MoveTowards(transform.position, destinoHorizontal, velocidadHorizontal * Time.deltaTime);

        // Si alcanza el punto A o B, cambia de dirección y desciende
        if (transform.position == destinoHorizontal)
        {
            moviendoHaciaB = !moviendoHaciaB; // Cambia entre A y B
            Descender();                      // Baja un poco
        }
    }

    void Descender()
    {
        // Desciende en el eje Y hacia abajo
        transform.position += Vector3.down * velocidadDescenso;
    }
}
