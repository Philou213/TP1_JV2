using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootCadence;
    private float timeBeforeShoot;
    private GameObject gun;
    private const int bulletPoolSize = 120;
    private GameObject[] bulletPool = new GameObject[bulletPoolSize];

    // Start is called before the first frame update
    void Start()
    {
        timeBeforeShoot = 0;
        gun = transform.Find("BobbleMarine-Body/Armature/Master Control/Hips/Torso/Shoulder.R/Forearm.R/Hand.R/Hand.R 1/Gun.001/Gun/Gun end").gameObject;
    }

    private void Awake()
    {
        InitializePoolSize();
    }

    void InitializePoolSize()
    {
        GameObject bulletListParent = new GameObject("BulletPool");
        for (int i = 0; i < bulletPoolSize; i++) 
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.SetParent(bulletListParent.transform);
            bullet.SetActive(false);
            bulletPool[i] = bullet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShootsBullet();
        updateTimeBeforeShoot();
    }

    private void ShootsBullet()
    {
        if (Input.GetButton("Fire1") && timeBeforeShoot == 0)
        {
            SpawnBullet();
            //GameObject bulletInstance = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            timeBeforeShoot = shootCadence;
        }
    }

    private void SpawnBullet()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject currentBullet = bulletPool[i];
            if (!currentBullet.activeSelf)
            { 
                currentBullet.transform.SetPositionAndRotation(gun.transform.position, gun.transform.rotation);
                currentBullet.SetActive(true);
                return;
            }
        }
    }

    private void updateTimeBeforeShoot()
    {
        timeBeforeShoot -= Time.deltaTime;
        if (timeBeforeShoot < 0)
        {
            timeBeforeShoot = 0;
        }
    }
}
