using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Properties")]
    [Tooltip("Efecto visual o sonido al recoger el objeto (opcional).")]
    public GameObject pickupEffect;

    /// <summary>
    /// M�todo que se ejecuta cuando el jugador colisiona con el item.
    /// Sobrescribir este m�todo en clases derivadas para comportamientos espec�ficos.
    /// </summary>
    /// <param name="player">El objeto Player que recoge el �tem.</param>
    protected virtual void OnPickup(GameObject player)
    {
        // Activar efecto de recogida, si existe
        if (pickupEffect)
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f); // Destruye el efecto despu�s de un tiempo
        }

        // Destruir el �tem despu�s de recogerlo
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickup(collision.gameObject);
        }
    }
}
