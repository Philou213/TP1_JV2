using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxNbOfConcurrentAliens;
    [SerializeField] private int maxTotalNbOfSpawnedAliens;
    [SerializeField] private GameObject alienPrefab;
    [SerializeField] private UnityEvent gameWonEvent;
    [SerializeField] private AlienSpawnController alienSpawnController;

    private InputManager inputManager;
    private GameObject spawnersGroup;
    private GameObject aliensGroup;

    private bool hasActiveSpawners = true;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        spawnersGroup = GameObject.Find("Spawners");
        aliensGroup = GameObject.Find("Aliens");
        InstantiateAliens();
        alienSpawnController.AddAliensAndSpawnersToList();
    }

    void Update()
    {
        CheckQuitGame();
    }

    private void CheckQuitGame()
    {
        bool quit;
        if (inputManager.gamepadUse)
        {
            quit = Input.GetButton("ExitGamepad");
        }
        else
        {
            quit = Input.GetButton("ExitKeyboard");
        }
        if (quit)
        {
            Application.Quit();
        }
    }

    private void InstantiateAliens()
    {
        for (int i = 0; i < maxNbOfConcurrentAliens; i++)
        {
            GameObject alien = Instantiate(alienPrefab);
            AlienController alienController = alien.GetComponent<AlienController>();
            alienController.alienDestroyedEvent.AddListener(OnAlienDestroyed);
            alien.SetActive(false);
            alien.transform.parent = aliensGroup.transform;
        }
    }

    public void OnAlienDestroyed()
    {
        if (!hasActiveSpawners)
        {
            for (int i = 0; i < aliensGroup.transform.childCount; i++)
            {
                if (aliensGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                    return;
            }

            WinGame();
        }
    }

    public void OnSpawnerDestroyed()
    {
        for (int i = 0; i < spawnersGroup.transform.childCount; i++)
        {
            if (spawnersGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                return;
        }
        hasActiveSpawners = false;
        OnAlienDestroyed();
    }

    private void WinGame()
    {
        gameWonEvent.Invoke();
    }
}
