using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    private PlayerHealth playerHealthScript;

    private void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("PickupHealth"))
        {
            playerHealthScript.AddLive();
        }
    }
}
