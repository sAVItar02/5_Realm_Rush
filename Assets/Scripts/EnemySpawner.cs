using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
