using System.Collections; // Asegúrate de importar esto para usar IEnumerator
using UnityEngine;

public class SpeedBoostItem : Item
{
    [Header("Speed Boost Properties")]
    public float speedMultiplier = 1.5f; // Multiplicador de la velocidad
    public float boostDuration = 5f;    // Duración del aumento de velocidad

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player);

        Player playerScript = player.GetComponent<Player>();
        if (playerScript)
        {
            StartCoroutine(ApplySpeedBoost(playerScript));
            Debug.Log($"Velocidad aumentada en {speedMultiplier}x por {boostDuration} segundos.");
        }
    }

    private IEnumerator ApplySpeedBoost(Player player)
    {
        // Guardar la velocidad original del jugador
        float originalSpeed = player.moveSpeed;

        // Aplicar el aumento de velocidad
        player.moveSpeed *= speedMultiplier;

        // Esperar la duración del aumento de velocidad
        yield return new WaitForSeconds(boostDuration);

        // Restaurar la velocidad original
        player.moveSpeed = originalSpeed;
        Debug.Log("Velocidad restaurada a la normalidad.");
    }
}
