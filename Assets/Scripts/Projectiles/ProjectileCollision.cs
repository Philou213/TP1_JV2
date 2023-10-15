using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "Missile" && (collision.gameObject.tag == "Alien" || collision.gameObject.tag == "Spawner"))
        {
            return;
        }
        else
        {
            DesactiveBullet();
        }
    }

    private void DesactiveBullet()
    {
        gameObject.SetActive(false);

    }
}
