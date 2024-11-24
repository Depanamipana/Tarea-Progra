using UnityEngine;

public class ImmunityItem : Item
{
    protected override void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.shieldActive = true;
            Debug.Log("Inmunidad activada.");
        }
    }

    protected override void OnEffectEnd(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.shieldActive = false;
            Debug.Log("Inmunidad terminada.");
        }
    }
}
