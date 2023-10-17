using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private AudioClip alienDeath;
    [SerializeField] private AudioClip marineDeath;
    [SerializeField] private AudioClip marineHurt;
    [SerializeField] private AudioClip missileShot;
    [SerializeField] private AudioClip powerupAppear;
    [SerializeField] private AudioClip powerupPickup;
    [SerializeField] private AudioClip healthPickup;
    [SerializeField] private AudioClip shootsPickup;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip tripleShoot;
    [SerializeField] private AudioClip victorySound;

    public AudioClip alienDeathClip { get { return alienDeath; } }
    public AudioClip marineDeathClip { get { return marineDeath; } }
    public AudioClip marineHurtClip { get { return marineHurt; } }
    public AudioClip missileShotClip { get { return missileShot; } }
    public AudioClip powerupAppearClip { get { return powerupAppear; } }
    public AudioClip powerupPickupClip { get { return powerupPickup; } }
    public AudioClip healthPickupClip { get { return healthPickup; } }
    public AudioClip shootsPickupClip { get { return shootsPickup; } }
    public AudioClip shootClip { get { return shoot; } }
    public AudioClip tripleShootClip { get { return tripleShoot; } }
    public AudioClip victorySoundClip { get { return victorySound; } }

    void Start()
    {
        if (instance == null) instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
