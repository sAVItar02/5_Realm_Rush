using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 10;
    int damgeOnHit = 1;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth = playerHealth - damgeOnHit;
        Debug.Log(playerHealth);
    }
}
