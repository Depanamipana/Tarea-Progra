using System.Collections;
using UnityEngine;

public class RapidFireItem : Item
{
    [Header("Rapid Fire Item Properties")]
    public float fireRateMultiplier = 0.5f; // Reduce el tiempo entre disparos a la mitad
    public float boostDuration = 5f;

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            StartCoroutine(EnableRapidFire(playerScript));
            Debug.Log($"Disparo rápido activado por {boostDuration} segundos.");
        }
    }

    private IEnumerator EnableRapidFire(Player player)
    {
        float originalFireRate = player.fireRate;
        player.fireRate *= fireRateMultiplier;

        yield return new WaitForSeconds(boostDuration);

        player.fireRate = originalFireRate;
        Debug.Log("Disparo rápido desactivado.");
    }
}
