using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    private int nbOfMissiles = 0;
    private GameObject gun;
    private const int missilePoolSize = 20;
    private GameObject[] missilePool = new GameObject[missilePoolSize];
    [SerializeField] private float shootCadence;
    [SerializeField] private GameObject missilePrefab;
    private float timeBeforeShoot;
    private UIManager uiManager;

    private void Start()
    {
        timeBeforeShoot = 0;
        gun = transform.Find("BobbleMarine-Body/Armature/Master Control/Hips/Torso/Shoulder.R/Forearm.R/Hand.R/Hand.R 1/Gun.001/Gun/Gun end").gameObject;
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    private void Awake()
    {
        InitializePoolSize();
    }

    private void Update()
    {
        ShootsMissile();
        UpdateTimeBeforeShoot();
    }

    private void ShootsMissile()
    {
        if (Input.GetButton("Fire2") && !Input.GetButton("Fire1") && timeBeforeShoot == 0 && nbOfMissiles > 0)
        {
            SpawnMissile();
            nbOfMissiles--;
            timeBeforeShoot = shootCadence;
            uiManager.UpdateMissileText(nbOfMissiles);
        }
    }

    private void SpawnMissile()
    {
        for (int i = 0; i < missilePoolSize; i++)
        {
            GameObject currentMissile = missilePool[i];
            if (!currentMissile.activeSelf)
            {
                currentMissile.transform.position = gun.transform.position;
                //TODO : Set missile rotation
                currentMissile.GetComponent<ProjectileMovement>().SetDirection(gun.transform.root.forward.normalized);
                currentMissile.SetActive(true);
                return;
            }
        }
    }

    public void GiveMissiles(int missilesToGive)
    {
        nbOfMissiles += missilesToGive;
        uiManager.UpdateMissileText(nbOfMissiles);
    }

    void InitializePoolSize()
    {
        GameObject bulletListParent = new GameObject("MissilePool");
        for (int i = 0; i < missilePoolSize; i++)
        {
            GameObject missile = Instantiate(missilePrefab);
            missile.transform.SetParent(bulletListParent.transform);
            missile.SetActive(false);
            missilePool[i] = missile;
        }
    }

    private void UpdateTimeBeforeShoot()
    {
        timeBeforeShoot -= Time.deltaTime;
        if (timeBeforeShoot < 0)
        {
            timeBeforeShoot = 0;
        }
    }
}
