using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> chunkPrefabs;
    public Transform chunkContainer;
    public ItemSpawner itemSpawner;

    public float spawnDistance = 20f;

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
        // Pick random chunk
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        GameObject newChunk = Instantiate(prefab, pos, rot, chunkContainer);

        activeChunks.Add(newChunk);

        // Get Chunk component
        Chunk chunk = newChunk.GetComponent<Chunk>();
        lastExit = chunk.exitPoint;

        // Spawn collectibles in this chunk
        itemSpawner.SpawnInChunk(chunk);

        // Delete the oldest chunk if more than 3 exist
        if (activeChunks.Count > 3)
        {
            Destroy(activeChunks[0]);
            activeChunks.RemoveAt(0);
        }
    }
}