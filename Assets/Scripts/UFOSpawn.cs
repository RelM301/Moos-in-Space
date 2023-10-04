using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    public GameObject[] ufoPrefabs;
    private float spawnPosY = -1.54f;

    private float initialDelay = 3f;
    private float initialSpawnInterval = 7f;

    private float difficultyIncreaseInterval = 35f;
    private float minSpawnInterval = 2f;
    private float maxSpawnInterval = 5f;
    private float minDelay = 1f;
    private float maxDelay = 3f;

    private int currentPrefabIndex = 2; // The index of the last prefab spawned

    private void Start()
    {
        InvokeRepeating("SpawnUfo", initialDelay, initialSpawnInterval);
        StartCoroutine(IncreaseDifficulty());
    }

    private IEnumerator IncreaseDifficulty()
    {
        yield return new WaitForSeconds(difficultyIncreaseInterval);

        while (true)
        {
            currentPrefabIndex++;
            currentPrefabIndex = Mathf.Clamp(currentPrefabIndex, 0, ufoPrefabs.Length - 1);

            float spawnInterval = Mathf.Clamp(initialSpawnInterval - (0.5f * currentPrefabIndex), minSpawnInterval, maxSpawnInterval);
            float spawnDelay = Mathf.Clamp(initialDelay - (0.2f * currentPrefabIndex), minDelay, maxDelay);

            InvokeRepeating("SpawnUfo", spawnDelay, spawnInterval);

            yield return new WaitForSeconds(difficultyIncreaseInterval);
        }
    }

    private void SpawnUfo()
    {
        int ufoIndex = Random.Range(0, currentPrefabIndex + 1); // Only spawn the UFOs up to the current prefab index

        bool spawnFromLeft = Random.Range(0, 2) == 0;

        Vector3 spawnPos;

        if (spawnFromLeft)
        {
            spawnPos = new Vector3(-9, spawnPosY, 0);
        }
        else
        {
            spawnPos = new Vector3(9, spawnPosY, 0);
        }

        GameObject newUFO = Instantiate(ufoPrefabs[ufoIndex], spawnPos, Quaternion.identity);
        UFOController ufoController = newUFO.GetComponent<UFOController>();

        ufoController.Initialize(spawnFromLeft);
    }
}
