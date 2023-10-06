using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    private PlayerHealth playerHealthScript;
    private PlayerShoots playerShootsScript;
    private PlayerMissile playerMissileScript;
    [SerializeField] private float timeOfMultishoot;
    [SerializeField] private int nbOfMissiles;

    private void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        playerShootsScript = GetComponent<PlayerShoots>();
        playerMissileScript = GetComponent<PlayerMissile>();

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

        else if (collision.gameObject.CompareTag("PickupMissile"))
        {
            playerMissileScript.GiveMissiles(nbOfMissiles);
        }
    }
}
