using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnController : MonoBehaviour
{
    [SerializeField] private float spawnTimeInterval;
    private float timeSinceLastSpawn = 0.0f;
    private float spawnerRadius;

    private GameObject aliensGroup;
    private GameObject spawnersGroup;
    private List<GameObject> spawnerList = new List<GameObject>();
    private List<GameObject> alienList = new List<GameObject>();


    private void Start()
    {
        spawnersGroup = GameObject.Find("Spawners");
        aliensGroup = GameObject.Find("Aliens");
    }

    public void AddAliensAndSpawnersToList()
    {
        for (int i = 0; i < spawnersGroup.transform.childCount; i++)
        {
            spawnerList.Add(spawnersGroup.transform.GetChild(i).gameObject);
        }
        spawnerRadius = spawnerList[0].transform.lossyScale.y;

        for (int i = 0; i < aliensGroup.transform.childCount; i++)
        {
            alienList.Add(aliensGroup.transform.GetChild(i).gameObject);
        }
    }

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.fixedDeltaTime;

        if (timeSinceLastSpawn >= spawnTimeInterval)
            if (TrySpawnAlien())
                timeSinceLastSpawn = 0.0f;
    }

    private bool TrySpawnAlien()
    {
        for (int i = 0; i < alienList.Count; i++)
        {
            if (!alienList[i].activeInHierarchy)
            {
                Vector3 spawnPoint = GetRandomActiveSpawnerPosition();
                if (spawnPoint == Vector3.zero)
                    return false;
                spawnPoint.y -= spawnerRadius / 2;
                alienList[i].transform.position = spawnPoint;
                alienList[i].SetActive(true);
                return true;
            }
        }
        return false;
    }

    private Vector3 GetRandomActiveSpawnerPosition()
    {
        if (!AtLeastOneSpawnerActive())
            return Vector3.zero;

        while (true)
        {
            int spawnerIndex = Random.Range(0, spawnerList.Count);
            if (spawnerList[spawnerIndex].activeInHierarchy)
            {
                return spawnerList[spawnerIndex].transform.position;
            }
        }
    }

    private bool AtLeastOneSpawnerActive()
    {
        for (int i = 0; i < spawnersGroup.transform.childCount; i++)
        {
            if (spawnersGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                return true;

        }
        return false;
    }

    public void OnGameEnd()
    {
        enabled = false;
    }
}
