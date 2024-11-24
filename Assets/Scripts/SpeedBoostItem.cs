using UnityEngine;

public class SpeedBoostItem : Item
{
    public float speedMultiplier = 1.5f;

    protected override void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.moveSpeed *= speedMultiplier;
            Debug.Log($"Velocidad aumentada a {playerScript.moveSpeed}");
        }
    }

    protected override void OnEffectEnd(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.moveSpeed /= speedMultiplier;
            Debug.Log("Velocidad normal restaurada.");
        }
    }
}
