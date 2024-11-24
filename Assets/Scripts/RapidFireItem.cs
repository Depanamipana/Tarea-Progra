using UnityEngine;

public class RapidFireItem : Item
{
    public float fireRateMultiplier = 0.5f;

    protected override void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.fireRate *= fireRateMultiplier;
            Debug.Log($"Disparo rápido activado. Nuevo rate: {playerScript.fireRate}");
        }
    }

    protected override void OnEffectEnd(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.fireRate /= fireRateMultiplier;
            Debug.Log("Disparo rápido desactivado.");
        }
    }
}
