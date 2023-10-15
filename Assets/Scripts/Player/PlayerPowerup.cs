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
    [SerializeField] GameManager gameManager;

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
            collision.gameObject.SetActive(false);
            playerHealthScript.AddLive();
            gameManager.PlaySound(SoundManager.Instance.powerupPickupClip, collision.transform.position);
        }

        else if (collision.gameObject.CompareTag("PickupMultishoot"))
        {
            collision.gameObject.SetActive(false);
            playerShootsScript.GiveMultishoot(timeOfMultishoot);
            gameManager.PlaySound(SoundManager.Instance.powerupPickupClip, collision.transform.position);
        }

        else if (collision.gameObject.CompareTag("PickupMissile"))
        {
            collision.gameObject.SetActive(false);
            playerMissileScript.GiveMissiles(nbOfMissiles);
            gameManager.PlaySound(SoundManager.Instance.powerupPickupClip, collision.transform.position);
        }
    }
}
