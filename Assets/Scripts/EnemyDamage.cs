using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 10;
    [SerializeField] ParticleSystem enemyHitPrefab;
    [SerializeField] ParticleSystem enemyDeathPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(enemyHitPoints < 1)
        {
            KillEnemy();
        }
    }
    private void ProcessHit()
    {
        enemyHitPoints--;
        enemyHitPrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(enemyDeathPrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }
}
