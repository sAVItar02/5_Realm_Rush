using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    float secondsBetweenSpawn = 3f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] Text spawnnedEnemies;
    [SerializeField] Text waveNumberDisplay;
    [SerializeField] AudioClip spawnSound;
 
    int score = 0;
    int waveNumber = 1;
    int enemyNumber = 5;
    float secondsBetweenWaves = 20f; 
    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab.GetComponent<EnemyMovement>().movementDelay = 1.5f;
        spawnnedEnemies.text = score.ToString();
        waveNumberDisplay.text = waveNumber.ToString();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (waveNumber <= 10) // forever
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnSound);
            StartCoroutine(InstantiateEnemies());
            waveNumber++;
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenWaves);
            waveNumberDisplay.text = waveNumber.ToString();
            enemyNumber += 2;
            if (waveNumber < 5)
            {
                TimeManager();
            }
            else if(waveNumber >= 5 && waveNumber <8)
            {
                SetNewMaxTowers(5);
                HealthManager();
            }
            else
            {
                SetNewMaxTowers(6);
                HealthManager();
            }
        }
    }

    private void AddScore()
    {
        score += 5;
        spawnnedEnemies.text = score.ToString();
    }

    IEnumerator InstantiateEnemies()
    {
        for (var i = 0; i < enemyNumber; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    private void TimeManager()
    {
        secondsBetweenWaves += 5f;
        secondsBetweenSpawn -= 0.5f;
        enemyPrefab.GetComponent<EnemyMovement>().movementDelay -= 0.25f;
    }

    private void HealthManager()
    {
        secondsBetweenWaves = 35f;
        enemyNumber += 0;
        secondsBetweenSpawn = 1f;
        enemyPrefab.GetComponent<EnemyMovement>().movementDelay = 0.5f;
        enemyPrefab.GetComponent<EnemyDamage>().enemyHitPoints += 1;
    }

    private static void SetNewMaxTowers(int numberOfNewTowers)
    {
        GameObject world = GameObject.Find("World");
        TowerFactory newTowers = world.GetComponent<TowerFactory>();
        newTowers.maxTowers = numberOfNewTowers;
    }

}
