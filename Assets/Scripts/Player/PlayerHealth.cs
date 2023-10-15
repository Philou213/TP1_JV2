using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private int startLives;
    [SerializeField] private float timeOfInvinciblity;
    private UIManager uiManager;
    private float timeBeforeCanBeHit;
    private int currentLives;
    private GameObject soundEmittersGroup;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        timeBeforeCanBeHit = 0;
        currentLives = startLives;
        uiManager.UpdateLivesText(currentLives);
        soundEmittersGroup = GameObject.Find("SoundEmitters");
    }

    private void Update()
    {
        UpdateTimeBeforeCanBeHit();
    }

    private void RemoveLive()
    {
        if (timeBeforeCanBeHit == 0)
        {
            timeBeforeCanBeHit = timeOfInvinciblity;
            currentLives--;
            IsDead();
            uiManager.UpdateLivesText(currentLives);
        }
    }

    public void AddLive()
    {
        currentLives++;
        uiManager.UpdateLivesText(currentLives);
    }

    private void IsDead()
    {
        if (currentLives <= 0) 
        {
            gameManager.PlaySound(SoundManager.Instance.marineDeathClip, transform.position);
            gameObject.SetActive(false);
        } else
        {
            gameManager.PlaySound(SoundManager.Instance.marineHurtClip, transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            if (!(collision.transform.position.y < transform.position.y))
            {
                RemoveLive();
            }
        }
    }

    private void UpdateTimeBeforeCanBeHit()
    {
        timeBeforeCanBeHit -= Time.deltaTime;
        if (timeBeforeCanBeHit < 0) 
        {
            timeBeforeCanBeHit = 0;
        }
    }

    
}
