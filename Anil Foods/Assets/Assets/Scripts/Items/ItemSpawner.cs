using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemData[] items; // List of ScriptableObjects

    public void SpawnInChunk(Chunk chunk)
    {
        foreach (Transform point in chunk.spawnPoints)
        {
            if (Random.value < 0.5f)
            {
                // Pick a random item data
                ItemData data = items[Random.Range(0, items.Length)];

                // Instantiate its prefab (or use default cube)
                GameObject itemObj = Instantiate(
                    data.itemPrefab,
                    point.position,
                    Quaternion.identity
                );

                // Assign the ScriptableObject
                itemObj.GetComponent<ProductItem>().data = data;
            }
        }
    }
}
