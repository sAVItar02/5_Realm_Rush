using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
