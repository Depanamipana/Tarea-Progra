using System.Collections;
using UnityEngine;

public class DisparoItem : Item
{
    [Header("DisparoItem Properties")]
    [Tooltip("Nuevo valor de velocidad de disparo del jugador.")]
    public float newFireRate = 0.05f;
    [Tooltip("Tiempo en segundos que la velocidad de disparo será aumentada.")]
    public float duration = 5f;

    protected override void OnPickup(GameObject player)
    {
        base.OnPickup(player); // Llama a la lógica base para destruir el ítem y efectos

        // Intentar obtener el componente Player del jugador
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            // Aumentar la velocidad de disparo del jugador
            StartCoroutine(IncreaseFireRate(playerScript));
        }
    }

    private IEnumerator IncreaseFireRate(Player player)
    {
        // Guardar la tasa de disparo original
        float originalFireRate = player.fireRate;

        // Cambiar la tasa de disparo a la nueva velocidad
        player.fireRate = newFireRate;

        // Esperar el tiempo de duración
        yield return new WaitForSeconds(duration);

        // Restaurar la tasa de disparo original después del tiempo de duración
        player.fireRate = originalFireRate;
    }
}
