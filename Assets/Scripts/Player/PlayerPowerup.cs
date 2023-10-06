using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    private PlayerHealth playerHealthScript;
    private PlayerShoots playerShootsScript;
    [SerializeField] private float timeOfMultishoot;

    private void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        playerShootsScript = GetComponent<PlayerShoots>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PickupHealth"))
        {
            playerHealthScript.AddLive();
        }

        else if (collision.gameObject.CompareTag("PickupMultishoot"))
        {
            playerShootsScript.GiveMultishoot(timeOfMultishoot);
        }
    }
}
