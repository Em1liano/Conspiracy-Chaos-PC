using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip castleSoundtrack;
    public AudioClip caveSoundtrack;
    public AudioClip jungleSoundtrack;
    public AudioClip desertSoundtrack;
    public AudioClip iceSoundtrack;
    public AudioClip volcanoSoundtrack;
    private void Awake()
    {
        SetUpSingleton();
        _audioSource = GetComponent<AudioSource>();
    }
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Castle")
        {
            StopMusic();
            _audioSource.PlayOneShot(castleSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Boss Castle")
        {
            StopMusic();
            _audioSource.PlayOneShot(castleSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Cave")
        {
            StopMusic();
            _audioSource.PlayOneShot(caveSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Boss Cave")
        {
            StopMusic();
            _audioSource.PlayOneShot(caveSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Jungle")
        {
            StopMusic();
            _audioSource.PlayOneShot(jungleSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Boss Jungle")
        {
            StopMusic();
            _audioSource.PlayOneShot(jungleSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Desert")
        {
            StopMusic();
            _audioSource.PlayOneShot(desertSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Boss Desert")
        {
            StopMusic();
            _audioSource.PlayOneShot(desertSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Ice")
        {
            StopMusic();
            _audioSource.PlayOneShot(iceSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Boss Ice")
        {
            StopMusic();
            _audioSource.PlayOneShot(iceSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Volcano")
        {
            StopMusic();
            _audioSource.PlayOneShot(volcanoSoundtrack);
        }
        if (SceneManager.GetActiveScene().name == "Volcano")
        {
            StopMusic();
            _audioSource.PlayOneShot(volcanoSoundtrack);
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
