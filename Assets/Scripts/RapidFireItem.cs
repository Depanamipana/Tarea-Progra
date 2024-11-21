using System.Collections;
using UnityEngine;

public class RapidFireItem : Item
{
    [Header("Rapid Fire Item Properties")]
    public float fireRateMultiplier = 0.5f; // Reduce el tiempo entre disparos (m�s r�pido)
    public float rapidFireDuration = 5f;    // Duraci�n del efecto en segundos

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            // Iniciar la corrutina para el disparo r�pido
            StartCoroutine(EnableRapidFire(playerScript));
            Debug.Log($"Disparo r�pido activado. FireRate nuevo: {playerScript.fireRate}");
        }
    }

    private IEnumerator EnableRapidFire(Player player)
    {
        // Guardar el fireRate original
        float originalFireRate = player.fireRate;

        // Aplicar el nuevo fireRate
        player.fireRate *= fireRateMultiplier;

        // Esperar la duraci�n del disparo r�pido
        yield return new WaitForSeconds(rapidFireDuration);

        // Restaurar el fireRate original
        player.fireRate = originalFireRate;
        Debug.Log($"Disparo r�pido desactivado. FireRate restaurado a: {originalFireRate}");
    }
}
