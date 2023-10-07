using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    private void Spin()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0, 0);
    }
}
