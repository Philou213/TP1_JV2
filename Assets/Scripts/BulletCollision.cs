using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DesactiveBullet();
    }
    private void OnTriggerEnter(Collider other)
    {
        DesactiveBullet();
    }

    private void DesactiveBullet()
    {
        gameObject.SetActive(false);

    }
}
