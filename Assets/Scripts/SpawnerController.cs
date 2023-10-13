using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    [SerializeField] private UnityEvent spawnerDestroyedEvent;

    private int currentHp;

    private void Awake()
    {
        currentHp = healthPoints;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            LoseHP(1);
        }
    }

    private void LoseHP(int hpLost)
    {
        currentHp -= hpLost;

        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            spawnerDestroyedEvent.Invoke();
        }
    }
}
