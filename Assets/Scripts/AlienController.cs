using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    private bool isGrounded = false;

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
    }
    private void Start()
    {
        player = GameObject.Find("SpaceMarine");
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {

            if (isGrounded)
            {
                if (!agent.enabled)
                {
                    agent.enabled = true;
                }
                agent.SetDestination(player.transform.position);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
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
            gameObject.transform.position = disabledPosition;
            isGrounded = false;
            agent.enabled = false;
        }
    }
}
