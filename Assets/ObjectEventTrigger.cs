using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ObjectEventTrigger : MonoBehaviour
{
    [Header("Objects to Monitor")]
    [Tooltip("Lista de objetos a monitorear.")]
    public GameObject[] objectsToMonitor;

    [Header("Event to Trigger")]
    [Tooltip("Evento que se activará cuando todos los objetos desaparezcan o se desactiven.")]
    public UnityEvent onAllObjectsGone;

    [Header("Event Delay")]
    [Tooltip("Tiempo en segundos antes de ejecutar el evento.")]
    public float delayBeforeEvent = 0f;

    private bool eventTriggered = false;

    private void Update()
    {
        if (!eventTriggered && AreAllObjectsInactive())
        {
            eventTriggered = true; // Asegura que el evento solo se llame una vez
            StartCoroutine(TriggerEventWithDelay());
        }
    }

    private bool AreAllObjectsInactive()
    {
        foreach (GameObject obj in objectsToMonitor)
        {
            if (obj != null && obj.activeInHierarchy)
            {
                return false; // Si al menos un objeto está activo, retorna falso
            }
        }
        return true; // Todos los objetos están inactivos o son nulos
    }

    private IEnumerator TriggerEventWithDelay()
    {
        if (delayBeforeEvent > 0f)
        {
            yield return new WaitForSeconds(delayBeforeEvent);
        }

        onAllObjectsGone?.Invoke();
    }
}
