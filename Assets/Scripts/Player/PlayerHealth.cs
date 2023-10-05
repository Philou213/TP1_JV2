using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startLives;
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = startLives;
    }

    private void RemoveLive()
    {
        currentLives--;
        IsDead();
    }

    private void AddLive()
    {
        currentLives++;
    }

    private void IsDead()
    {
        if (currentLives <= 0) 
        {
            Debug.Log("Game over");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            RemoveLive();
        }
    }
}
