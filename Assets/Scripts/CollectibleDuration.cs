using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDuration : MonoBehaviour
{
    [SerializeField] private float maxDurationTime;
    private float durationTime;
    void Start()
    {
        durationTime = maxDurationTime;
    }

    private void OnEnable()
    {
        durationTime = maxDurationTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDurationTime();
    }

    private void UpdateDurationTime()
    {
        durationTime -= Time.deltaTime;
        {
            if (durationTime <= 0) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}
