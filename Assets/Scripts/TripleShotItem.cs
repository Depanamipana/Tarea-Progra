using UnityEngine;

public class TripleShotItem : Item
{
    [Header("Triple Shot Item Properties")]
    public GameObject tripleShotPrefab;

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript && tripleShotPrefab)
        {
            playerScript.playerLaser = tripleShotPrefab;
            Debug.Log("Disparo triple activado.");
        }
    }
}
