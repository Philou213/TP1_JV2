using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 gunDirection)
    {
        direction = gunDirection;
    }
}
