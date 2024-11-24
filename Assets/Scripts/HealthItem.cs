using UnityEngine;

public class HealthItem : Item
{
    [Header("Health Item Properties")]
    public int healthIncrease = 20;

    protected override void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.health += healthIncrease;
            Debug.Log($"Vida aumentada en {healthIncrease}. Vida actual: {playerScript.health}");
        }
    }
}
