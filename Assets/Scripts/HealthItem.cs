using UnityEngine;

public class HealthItem : Item
{
    [Header("Health Item Properties")]
    public int healthAmount = 20;

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            playerScript.health += healthAmount;
            Debug.Log($"Vida aumentada en {healthAmount}. Vida actual: {playerScript.health}");
        }
    }
}
