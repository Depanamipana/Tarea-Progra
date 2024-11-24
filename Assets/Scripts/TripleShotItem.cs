using System.Collections;
using UnityEngine;

public class TripleShotItem : Item
{
    protected override void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.StartCoroutine(TripleShot(playerScript));
            Debug.Log("Triple disparo activado.");
        }
    }

    private IEnumerator TripleShot(Player player)
    {
        while (useEffectDuration)
        {
            GameObject centerLaser = Instantiate(player.playerLaser, player.transform.position, Quaternion.identity);
            GameObject leftLaser = Instantiate(player.playerLaser, player.transform.position, Quaternion.Euler(0, 0, 15));
            GameObject rightLaser = Instantiate(player.playerLaser, player.transform.position, Quaternion.Euler(0, 0, -15));
            yield return new WaitForSeconds(player.fireRate);
        }
    }

    protected override void OnEffectEnd(GameObject player)
    {
        Debug.Log("Triple disparo desactivado.");
    }
}
