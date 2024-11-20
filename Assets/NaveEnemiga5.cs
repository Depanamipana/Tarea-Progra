using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga5 : Enemy
{
    [Header("Movement Settings")]
    public float zigzagAmplitude = 3f; // Amplitud del zigzag
    public float zigzagFrequency = 2f; // Frecuencia del zigzag
    public float verticalSpeed = 1f;   // Velocidad hacia abajo

    private float initialX; // Posición inicial en X

    void Start()
    {
        // Guardamos la posición inicial en X
        initialX = transform.position.x;
    }

    void Update()
    {
        ZigzagMove();
    }

    private void ZigzagMove()
    {
        // Calculamos el desplazamiento en X usando una función seno
        float offsetX = Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude;

        // Actualizamos la posición
        transform.position = new Vector3(initialX + offsetX, transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
    }
}
