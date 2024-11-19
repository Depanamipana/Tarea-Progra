using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> itemsToSpawn; // Lista de ítems asignados desde el Inspector
    public float spawnInterval = 5f; // Tiempo entre apariciones
    public float itemLifetime = 10f; // Tiempo que los ítems permanecen en pantalla

    [Header("Spawn Area")]
    public BoxCollider2D spawnArea; // Área donde los ítems serán generados

    private void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("BoxCollider2D no asignado. Por favor, asigna un BoxCollider2D al spawnArea.");
            return;
        }

        if (itemsToSpawn.Count == 0)
        {
            Debug.LogError("No hay ítems asignados en la lista. Por favor, asigna ítems en el inspector.");
            return;
        }

        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Generar un ítem aleatorio de la lista
            GameObject item = Instantiate(GetRandomItem());

            // Posicionar el ítem aleatoriamente dentro del BoxCollider2D
            item.transform.position = GetRandomPositionWithinArea();

            // Destruir el ítem después de itemLifetime segundos
            Destroy(item, itemLifetime);
        }
    }

    private GameObject GetRandomItem()
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Count);
        return itemsToSpawn[randomIndex];
    }

    private Vector2 GetRandomPositionWithinArea()
    {
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }

    private void OnDrawGizmos()
    {
        // Visualización del área de spawn
        if (spawnArea != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }
}
