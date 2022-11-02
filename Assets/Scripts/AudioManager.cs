using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;

    public AudioClip estrellasSFX;
    
    public AudioClip bombasSFX;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        //Si ya hay una instancia y no soy yo me destruyo
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void EstrellasSFX()
    {
        audioSource.PlayOneShot(estrellasSFX);
    }

    public void BombasSFX()
    {
        audioSource.PlayOneShot(bombasSFX);
    }
}
