using UnityEngine;

public class Item : MonoBehaviour
{
    [Tooltip("Efecto visual o sonido al recoger el objeto (opcional).")]
    public GameObject pickupEffect;

    protected virtual void OnPickup(GameObject player)
    {
        if (pickupEffect)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }
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
