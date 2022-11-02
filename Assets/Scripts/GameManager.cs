using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 3;

    public int estrellas = 0;

    
    void Awake()
    {
        //Si ya hay una instancia y no soy yo me destruyo
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void RestarVidas()
    {
        vidas--;

        if (hearts == 2)
        {
            HeartImage2.SetActive(false);
        }

        else if (hearts == 1)
        {
            HeartImage2.SetActive(false);
            HeartImage1.SetActive(false);
        }

        else (hearts == 0)
        {
            HeartImage2.SetActive(false);
            HeartImage1.SetActive(false);
            HeartImage.SetActive(false);
            DefeatText.SetActive(true);
        }
    }

    public void Estrellas()
    {
        estrellas++;
        if (stars == 3)
        {
            VictoryText.SetActive(true);
        }
    }
}
