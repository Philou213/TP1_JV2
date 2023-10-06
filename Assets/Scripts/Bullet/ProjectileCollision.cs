using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Missile"))
        {
            DesactiveBullet();
        }
    }

    private void DesactiveBullet()
    {
        gameObject.SetActive(false);

    }
}
