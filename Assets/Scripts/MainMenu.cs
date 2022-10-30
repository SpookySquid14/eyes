using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject playButton;
    public GameObject creditsBack;
    private void Awake()
    {
        mainMenu = GameObject.Find("Canvas/Manager/Main Menu");
        credits = GameObject.Find("Canvas/Manager/Credits");

        playButton = GameObject.Find("Canvas/Manager/Main Menu/Play Button");
        creditsBack = GameObject.Find("Canvas/Manager/Credits/Back Button");

        menus = new GameObject[2];

        menus[0] = mainMenu;
        menus[1] = credits;

        DisableAll(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credits()
    {
        DisableAll(1);
        EventSystem.current.SetSelectedGameObject(creditsBack);
    }
    public void Menu()
    {
        DisableAll(0);
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    public void DisableAll(int enable)
    {
        for (int currentMenu = 0; currentMenu < menus.Length; currentMenu++)
        {
            menus[currentMenu].SetActive(false);
        }
        menus[enable].SetActive(true);
    }
}
