using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementDelay = 0.5f;
    [SerializeField] ParticleSystem goalParticles;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementDelay);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticles, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx, vfx.main.duration);

        Destroy(gameObject);
    }
}
