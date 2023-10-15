using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AlienController : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    [SerializeField] public AlienKilledEvent alienKilledEvent;

    private int currentHp;
    private GameObject player;
    private NavMeshAgent agent;
    private Vector3 disabledPosition = new(0, -200, 0);

    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.enabled = false;
        currentHp = healthPoints;
    }
    private void Start()
    {
        player = GameObject.Find("SpaceMarine");
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            if (agent.enabled)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            agent.enabled = true;
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            LoseHP(1);
        }
        else if (collision.gameObject.tag == "Missile")
        {
            LoseHP(collision.gameObject.GetComponent<MissileExplosion>().GetMissileDamage());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            LoseHP(collision.gameObject.GetComponent<MissileExplosion>().GetMissileDamage());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SpaceMarine")
        {
            LoseHP(currentHp);
        }
    }

    private void LoseHP(int hpLost)
    {
        currentHp -= hpLost;

        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            agent.enabled = false;
            alienKilledEvent.Invoke(transform.position);
            transform.position = disabledPosition;
        }
    }
}
