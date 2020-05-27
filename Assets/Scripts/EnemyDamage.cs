using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyHitPoints = 10;
    [SerializeField] ParticleSystem enemyHitPrefab;
    [SerializeField] ParticleSystem enemyDeathPrefab;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioClip deathSound;

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
        GetComponent<AudioSource>().PlayOneShot(shotSound);
        enemyHitPoints--;
        enemyHitPrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(enemyDeathPrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);

        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);

        Destroy(gameObject);
    }


}
