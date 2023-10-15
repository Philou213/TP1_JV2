using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private float fadeOutTime;

    private AudioSource musicSource;
    private float timeSinceGameWon = 0f;
    private float baseVolume;


    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        baseVolume = musicSource.volume;
    }

    void FixedUpdate()
    {
    }

    //Code du fade trouvé ici https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
    private IEnumerator FadeMusic()
    {
        while (timeSinceGameWon < fadeOutTime)
        {
            timeSinceGameWon += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(musicSource.volume, 0, timeSinceGameWon / fadeOutTime);
            yield return null;
        }
        musicSource.volume = baseVolume;
        musicSource.loop = false;
        musicSource.clip = SoundManager.Instance.victorySoundClip;
        musicSource.Play();
        
        yield break;
    }

    public void OnGameWon()
    {
        StartCoroutine(FadeMusic());
    }
}
