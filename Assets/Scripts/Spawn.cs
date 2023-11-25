using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public float spawnInterval = 5.0f;


    private float timer;

    public GameObject player;
    void Start()
    {
        timer = spawnInterval;
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval;
            Debug.Log("Spawned enemy!");
            Debug.Log(timer);
        }

        if(spawnInterval < 5.0f)
        {
            spawnInterval += Time.deltaTime;
        }
        if(spawnInterval > 5.0f)
        {
            spawnInterval = 5.0f;
        }
    }

    void SpawnEnemy()
    {
        List<Transform> candidates = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<SpawnPoint>().occupied && child.GetComponent<SpawnPoint>().active)
            {
                candidates.Add(child);
            }
        }

        if (candidates.Count != 0)
        {
            int spawnIndex = Random.Range(0, candidates.Count);
            GameObject newEnemy = Instantiate(enemyPrefab, candidates[spawnIndex].position, Quaternion.identity);
            candidates[spawnIndex].GetComponent<SpawnPoint>().occupied = true;
            newEnemy.transform.SetParent(candidates[spawnIndex]);

            Enemy enemyScript = newEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.player = player.transform;
            }
        }

    }
}