using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Tower : MonoBehaviour
{
    public Waypoint baseWaypoint;

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem bulletParticles;

    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        getTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void getTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(testEnemy.transform , closestEnemy);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform tranformA, Transform transormB)
    {
        var distToA = Vector3.Distance(tranformA.position, transform.position);
        var distToB = Vector3.Distance(transormB.position, transform.position);

        if ( distToA > distToB )
        {
            return transormB;
        }
        else
        {
            return tranformA;
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position); 
        if(distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bulletParticles.emission;
        emissionModule.enabled = isActive;
    }
}
