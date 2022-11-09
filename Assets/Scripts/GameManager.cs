using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 3;

    public int estrellas = 0;

    public Text ScoreText;

    public GameObject HeartImage;

    public GameObject HeartImage1;

    public GameObject HeartImage2;

    public GameObject DefeatText;

    public GameObject DefeatBoard;

    public GameObject LooseImage;

    public GameObject VictoryText;

    public GameObject VictoryBoard;

    public GameObject WinImage;

    
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

        if (vidas == 2)
        {
            HeartImage2.SetActive(false);
        }
        
        else if (vidas == 1)
        {
            HeartImage2.SetActive(false);
            HeartImage1.SetActive(false);
        }

        else if (vidas == 0)
        {
            HeartImage2.SetActive(false);
            HeartImage1.SetActive(false);
            HeartImage.SetActive(false);
            DefeatText.SetActive(true);
            DefeatBoard.SetActive(true);
            LooseImage.SetActive(true);
        }
    }

    public void Estrellas()
    {
        estrellas++;
        ScoreText.text = "   " + estrellas;

        if (estrellas == 3)
        {
            VictoryText.SetActive(true);
            VictoryBoard.SetActive(true);
            WinImage.SetActive(true);
        }
    }
}
