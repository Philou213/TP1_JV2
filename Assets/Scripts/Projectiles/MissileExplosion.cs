using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    private float baseMissileRadius;
    [SerializeField] private int explosionDamage;

    private SphereCollider missileCollider;
    private bool hasExploded = false;

    private void Start()
    {
        missileCollider = gameObject.GetComponent<SphereCollider>();
        baseMissileRadius = missileCollider.radius;
    }

    private void FixedUpdate()
    {
        if (hasExploded)
        {
            missileCollider.radius = baseMissileRadius;
            hasExploded = false;
            gameObject.SetActive(false);
        }
        if (missileCollider.radius > baseMissileRadius)
        {
            hasExploded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Alien" || collision.gameObject.tag == "Spawner")
        {
            if (!hasExploded)
            {
                missileCollider.radius = explosionRadius;
            }
        }
    }

    public int GetMissileDamage() {
        if (!hasExploded)
        {
            return 0;
        }
        return explosionDamage; 
    }
}
