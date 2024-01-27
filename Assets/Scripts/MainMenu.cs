using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartGame;

    public GameObject Controls;
    public GameObject Credits;
    public GameObject StartMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OK()
    {
        SceneManager.LoadScene(StartGame);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {

    }

    public void OpenControls()
    {
        StartMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void OpenCredits()
    {
        StartMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void BackFromControls()
    {
        StartMenu.SetActive(true);
        Controls.SetActive(false);
    }

    public void BackFromCredits()
    {
        StartMenu.SetActive(true);
        Credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
