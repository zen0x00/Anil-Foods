using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> chunkPrefabs;
    public Transform chunkContainer;
    public ItemSpawner itemSpawner;

    public float spawnDistance = 20f;

    private int chunkCount = 0;

    private Transform lastExit;
    private List<GameObject> activeChunks = new List<GameObject>();

    void Start()
    {
        // Spawn first chunk
        SpawnChunk(Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        // Spawn next chunk when player approaches the exit
        if (Vector3.Distance(player.position, lastExit.position) < spawnDistance)
        {
            SpawnChunk(lastExit.position, lastExit.rotation);
        }
    }

    void SpawnChunk(Vector3 pos, Quaternion rot)
    {
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        GameObject newChunk = Instantiate(prefab, pos, rot, chunkContainer);

        activeChunks.Add(newChunk);

        Chunk chunk = newChunk.GetComponent<Chunk>();
        lastExit = chunk.exitPoint;

        chunkCount++;

        // Spawn items ONLY from the 2nd chunk onwards
        if (chunkCount > 1)
        {
            itemSpawner.SpawnInChunk(chunk);
        }

        // Remove old chunks
        if (activeChunks.Count > 3)
        {
            Destroy(activeChunks[0]);
            activeChunks.RemoveAt(0);
        }
    }
}
