using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item Properties")]
    public float effectDuration = 0f; // Duraci�n del efecto en segundos
    public bool useEffectDuration = false; // Si es verdadero, el efecto tendr� duraci�n limitada

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickup(other.gameObject);

            if (useEffectDuration && effectDuration > 0)
            {
                // Aseguramos que se ejecute la rutina correctamente
                StartCoroutine(ApplyEffectWithDuration(other.gameObject));
            }
            else
            {
                Destroy(gameObject); // Elimina el �tem inmediatamente
            }
        }
    }

    // M�todo para aplicar el efecto con duraci�n
    private IEnumerator ApplyEffectWithDuration(GameObject player)
    {
        yield return new WaitForSeconds(effectDuration);
        OnEffectEnd(player); // Finaliza el efecto despu�s del tiempo
        Destroy(gameObject); // Destruye el �tem
    }

    // M�todo base para aplicar el efecto (debe ser implementado por los hijos)
    protected abstract void OnPickup(GameObject player);

    // M�todo base para finalizar el efecto (opcional, implementado por los hijos si es necesario)
    protected virtual void OnEffectEnd(GameObject player)
    {
        Debug.Log("Efecto finalizado: " + gameObject.name);
    }
}
