using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] int damgeOnHit = 1;
    [SerializeField] Text healthText;

    public HealthBar healthBar;

    private void Start()
    {
        healthBar.SetMaxHealth(playerHealth);
        //healthText.text = playerHealth.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        playerHealth -= damgeOnHit;
        healthBar.SetHealth(playerHealth);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        //healthText.text = playerHealth.ToString();
    }
}
