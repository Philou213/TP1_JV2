using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootCadence;
    private float timeBeforeShoot;
    private GameObject gun;
    private const int bulletPoolSize = 200;
    private GameObject[] bulletPool = new GameObject[bulletPoolSize];
    private float timeOfMultishoot;
    private const int bulletsInMultishoot = 3;
    private UIManager uiManager;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        inputManager = GameObject.Find("GameManager").GetComponent<InputManager>();
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
        UpdateTimeBeforeShoot();
        UpdateTimeOfMultishoot();
    }

    private void ShootsBullet()
    {
        if (IsFiring() && timeBeforeShoot == 0)
        {
            SpawnBullet();
            timeBeforeShoot = shootCadence;
        }
    }

    private bool IsFiring()
    {
        if (inputManager.gamepadUse)
        {
            return Input.GetAxis("FireBulletGamepad") != 0 && Input.GetAxis("FireMissileGamepad") == 0;
        }
        return Input.GetButton("FireBulletKeyboard") && !(Input.GetButton("FireMissileKeyboard"));
    }

    private void SpawnBullet()
    {
        int ballsToShoot = 1;
        if (timeOfMultishoot > 0) 
        {
            ballsToShoot = bulletsInMultishoot;
        }

        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject currentBullet = bulletPool[i];
            if (!currentBullet.activeSelf)
            { 
                currentBullet.transform.position = gun.transform.position;
                Vector3 bulletDirection = SetBulletDirection(ballsToShoot);
                currentBullet.GetComponent<ProjectileMovement>().SetDirection(bulletDirection);
                currentBullet.SetActive(true);
                ballsToShoot--;
                if (ballsToShoot == 0)
                {
                    return;
                }
            }
        }
    }

    private Vector3 SetBulletDirection(int indexBullet)
    {
        Vector3 forward = gun.transform.root.forward;
        switch (indexBullet) 
        {
            case 1:
                {
                    return forward.normalized;
                }
            case 2:
                {
                    return (forward * 0.5f + transform.right * 0.5f).normalized;
                }
            case 3:
                {
                    return (forward * 0.5f - transform.right * 0.5f).normalized;
                }
            default:
                {
                    return forward.normalized;
                }
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

    private void UpdateTimeOfMultishoot()
    {
        timeOfMultishoot -= Time.deltaTime;
        if (timeOfMultishoot < 0)
        {
            timeOfMultishoot = 0;
        }
        else
        {
            uiManager.UpdateMultishootText((int)timeOfMultishoot);
        }
    }

    public void GiveMultishoot(float timeToGive)
    {
        timeOfMultishoot += timeToGive;
    }
}
