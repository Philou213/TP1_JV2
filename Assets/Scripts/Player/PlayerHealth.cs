using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startLives;
    [SerializeField] private float timeOfInvinciblity;
    private float timeBeforeCanBeHit;
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        timeBeforeCanBeHit = 0;
        currentLives = startLives;
    }

    private void Update()
    {
        UpdateTimeBeforeCanBeHit();
    }

    private void RemoveLive()
    {
        if (timeBeforeCanBeHit == 0)
        {
            timeBeforeCanBeHit = timeOfInvinciblity;
            currentLives--;
            IsDead();
        }
    }

    private void AddLive()
    {
        currentLives++;
    }

    private void IsDead()
    {
        if (currentLives <= 0) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            RemoveLive();
        }
    }

    private void UpdateTimeBeforeCanBeHit()
    {
        timeBeforeCanBeHit -= Time.deltaTime;
        if (timeBeforeCanBeHit < 0) 
        {
            timeBeforeCanBeHit = 0;
        }
    }
}
