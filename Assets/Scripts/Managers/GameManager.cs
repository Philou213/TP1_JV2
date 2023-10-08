using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxNbOfConcurrentAliens;
    [SerializeField] private int maxTotalNbOfSpawnedAliens;
    [SerializeField] private GameObject alienPrefab;
    private InputManager inputManager;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        InstantiateAliens();
    }

    void Update()
    {
        QuitGame();
    }

    private void QuitGame()
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
        GameObject aliensGroup = GameObject.Find("Aliens");

        for (int i = 0; i < maxNbOfConcurrentAliens; i++)
        {
            GameObject alien = Instantiate(alienPrefab);
            alien.SetActive(false);
            alien.transform.parent = aliensGroup.transform;
        }
    }
}
