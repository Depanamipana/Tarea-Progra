using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Item Properties")]
    public float effectDuration = 0f; // Duración del efecto en segundos
    public bool useEffectDuration = false; // Si es verdadero, el efecto tendrá duración limitada

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
                Destroy(gameObject); // Elimina el ítem inmediatamente
            }
        }
    }

    // Método para aplicar el efecto con duración
    private IEnumerator ApplyEffectWithDuration(GameObject player)
    {
        yield return new WaitForSeconds(effectDuration);
        OnEffectEnd(player); // Finaliza el efecto después del tiempo
        Destroy(gameObject); // Destruye el ítem
    }

    // Método base para aplicar el efecto (debe ser implementado por los hijos)
    protected abstract void OnPickup(GameObject player);

    // Método base para finalizar el efecto (opcional, implementado por los hijos si es necesario)
    protected virtual void OnEffectEnd(GameObject player)
    {
        Debug.Log("Efecto finalizado: " + gameObject.name);
    }
}
