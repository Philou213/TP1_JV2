using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private int maxConcurrentCollectibles;

    [Range(0, 100)]
    [SerializeField] private int collectibleDropRate;

    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private GameObject shootsPrefab;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] GameManager gameManager;

    private GameObject healthGroup;
    private GameObject shootsGroup;
    private GameObject missileGroup;

    const int COLLECTIBLE_SPAWN_HEIGHT = -72;

    void Start()
    {
        healthGroup = GameObject.Find("HealthCollectibles");
        shootsGroup = GameObject.Find("ShootsCollectibles");
        missileGroup = GameObject.Find("MissileCollectibles");
        InstantiateCollectibles();

        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.alienKilledEvent.AddListener(OnAlienKilled);
    }

    public void OnAlienKilled(Vector3 position)
    {
        int randomPercent = Random.Range(0, 101);

        if (randomPercent <= collectibleDropRate)
        {
            position.y = COLLECTIBLE_SPAWN_HEIGHT;
            SpawnRandomCollectible(position);
        }
    }

    private void SpawnRandomCollectible(Vector3 spawnPoint)
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0:
                {
                    for (int i = 0; i < healthGroup.transform.childCount; i++)
                    {
                        if (!healthGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                        {
                            SpawnCollectible(healthGroup.transform.GetChild(i).gameObject, spawnPoint);
                            break;
                        }
                    }
                    break;
                }
            case 1:
                {
                    for (int i = 0; i < shootsGroup.transform.childCount; i++)
                    {
                        if (!shootsGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                        {
                            SpawnCollectible(shootsGroup.transform.GetChild(i).gameObject, spawnPoint);
                            break;
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (int i = 0; i < missileGroup.transform.childCount; i++)
                    {
                        if (!missileGroup.transform.GetChild(i).gameObject.activeInHierarchy)
                        {
                            SpawnCollectible(missileGroup.transform.GetChild(i).gameObject, spawnPoint);
                            break;
                        }
                    }
                    break;
                }
        }
    }

    private void SpawnCollectible(GameObject collectible, Vector3 spawnPoint)
    {

        collectible.transform.position = spawnPoint;
        collectible.SetActive(true);
        gameManager.PlaySound(SoundManager.Instance.powerupAppearClip, spawnPoint);
    }

    private void InstantiateCollectibles()
    {
        for (int i = 0; i < maxConcurrentCollectibles; i++)
        {
            GameObject collectible = Instantiate(healthPrefab);
            collectible.SetActive(false);
            collectible.transform.parent = healthGroup.transform;
        }
        for (int i = 0; i < maxConcurrentCollectibles; i++)
        {
            GameObject collectible = Instantiate(shootsPrefab);
            collectible.SetActive(false);
            collectible.transform.parent = shootsGroup.transform;
        }
        for (int i = 0; i < maxConcurrentCollectibles; i++)
        {
            GameObject collectible = Instantiate(missilePrefab);
            collectible.SetActive(false);
            collectible.transform.parent = missileGroup.transform;
        }
    }
}
