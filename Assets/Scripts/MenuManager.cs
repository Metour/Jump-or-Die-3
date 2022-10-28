using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject title;
    public GameObject mainButtons;
    public GameObject optionsMenu;

    public void OpenOptions()
    {
        title.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Platforms");
    }
}
