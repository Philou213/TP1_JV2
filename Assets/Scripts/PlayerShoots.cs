using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = transform.Find("BobbleMarine-Body/Armature/Master Control/Hips/Torso/Shoulder.R/Forearm.R/Hand.R/Hand.R 1/Gun.001/Gun").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ShootsBullet();
    }

    private void ShootsBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            bulletInstance.transform.Rotate(90f, 0f, 0f);
        }
    }
}
