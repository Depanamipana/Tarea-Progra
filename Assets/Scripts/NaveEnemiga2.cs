using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemiga2 : Enemy
{
    public float velocidad = 3f; 
    private int pasoActual = 0;  
    private float tiempoMovimiento = 1f; 
    private float tiempoTranscurrido = 0f; 

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoMovimiento)
        {
            tiempoTranscurrido = 0f;
            pasoActual = (pasoActual + 1) % 4; 
        }
        
        switch (pasoActual)
        {
            case 0:
                transform.position += Vector3.left * velocidad * Time.deltaTime;
                break;
            case 1:
                transform.position += Vector3.down * velocidad * Time.deltaTime;
                break;
            case 2:
                transform.position += Vector3.right * velocidad * Time.deltaTime;
                break;
            case 3:
                transform.position += Vector3.down * velocidad * Time.deltaTime;
                break;
        }
    }
}
