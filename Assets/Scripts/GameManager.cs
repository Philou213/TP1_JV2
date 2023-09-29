using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxNbOfConcurrentAliens;
    [SerializeField] private int maxTotalNbOfSpawnedAliens;
    [SerializeField] private GameObject alienPrefab;

    private GameObject aliensGroup;
    private List<GameObject> spawnerList = new List<GameObject>();
    private List<GameObject> alienList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnersGroup = GameObject.Find("Spawners");
        for (int i = 0; i < spawnersGroup.transform.childCount; i++)
        {
            spawnerList.Add(spawnersGroup.transform.GetChild(i).gameObject);
        }
        instantiateAliens();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void instantiateAliens()
    {
        aliensGroup = GameObject.Find("Aliens");

        for (int i = 0; i < maxNbOfConcurrentAliens; i++)
        {
            GameObject alien = Instantiate(alienPrefab);
            alien.SetActive(false);
            alien.transform.parent = aliensGroup.transform;
            alienList.Add(alien);
        }
    }
}
