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
    private InputManager inputManager;

    private void Start()
    {
        timeBeforeShoot = 0;
        gun = transform.Find("BobbleMarine-Body/Armature/Master Control/Hips/Torso/Shoulder.R/Forearm.R/Hand.R/Hand.R 1/Gun.001/Gun/Gun end").gameObject;
        uiManager = FindAnyObjectByType<GameManager>().GetComponent<UIManager>();
        inputManager = FindAnyObjectByType<GameManager>().GetComponent<InputManager>();
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
        if (IsFiring() && timeBeforeShoot == 0 && nbOfMissiles > 0)
        {
            SpawnMissile();
            nbOfMissiles--;
            timeBeforeShoot = shootCadence;
            uiManager.UpdateMissileText(nbOfMissiles);
        }
    }

    private bool IsFiring()
    {
        if (inputManager.gamepadUse)
        {
            return Input.GetAxis("FireMissileGamepad") != 0 && Input.GetAxis("FireBulletGamepad") == 0;
        }
        return Input.GetButton("FireMissileKeyboard") && !(Input.GetButton("FireBulletKeyboard"));
    }

    private void SpawnMissile()
    {
        for (int i = 0; i < missilePoolSize; i++)
        {
            GameObject currentMissile = missilePool[i];
            if (!currentMissile.activeSelf)
            {
                currentMissile.transform.position = gun.transform.position;
                Vector3 gunDirection = gun.transform.root.forward.normalized;
                Quaternion missileRotation = Quaternion.LookRotation(gunDirection);
                currentMissile.transform.rotation = missileRotation;
                currentMissile.GetComponent<ProjectileMovement>().SetDirection(new Vector3(0,0,1));
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
