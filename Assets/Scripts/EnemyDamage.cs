using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(enemyHitPoints < 1)
        {
            Destroy(gameObject);
        }
    }

    private void ProcessHit()
    {
        enemyHitPoints--;
        print("Enemy Heath = " + enemyHitPoints);
    }
}
