using System.Collections;
using UnityEngine;

public class ImmunityItem : Item
{
    [Header("Immunity Item Properties")]
    public float immunityDuration = 5f;

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            playerScript.StartCoroutine(GrantImmunity(playerScript));
            Debug.Log($"Inmunidad activada por {immunityDuration} segundos.");
        }
    }

    private IEnumerator GrantImmunity(Player player)
    {
        player.shieldActive = true; // Usa el escudo como inmunidad
        yield return new WaitForSeconds(immunityDuration);
        player.shieldActive = false;
        Debug.Log("Inmunidad desactivada.");
    }
}
