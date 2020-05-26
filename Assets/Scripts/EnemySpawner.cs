using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] Text spawnnedEnemies;
    [SerializeField] AudioClip spawnSound;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnnedEnemies.text = score.ToString();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // forever
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnSound);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    private void AddScore()
    {
        score += 5;
        spawnnedEnemies.text = score.ToString();
    }

}
