using System.Collections;
using UnityEngine;

public class RapidFireItem : Item
{
    [Header("Rapid Fire Item Properties")]
    public float fireRateMultiplier = 0.5f; // Reduce el tiempo entre disparos (más rápido)
    public float rapidFireDuration = 5f;    // Duración del efecto en segundos

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            // Iniciar la corrutina para el disparo rápido
            StartCoroutine(EnableRapidFire(playerScript));
            Debug.Log($"Disparo rápido activado. FireRate nuevo: {playerScript.fireRate}");
        }
    }

    private IEnumerator EnableRapidFire(Player player)
    {
        // Guardar el fireRate original
        float originalFireRate = player.fireRate;

        // Aplicar el nuevo fireRate
        player.fireRate *= fireRateMultiplier;

        // Esperar la duración del disparo rápido
        yield return new WaitForSeconds(rapidFireDuration);

        // Restaurar el fireRate original
        player.fireRate = originalFireRate;
        Debug.Log($"Disparo rápido desactivado. FireRate restaurado a: {originalFireRate}");
    }
}
