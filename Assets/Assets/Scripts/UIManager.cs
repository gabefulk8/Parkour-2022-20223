using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlMenu;
    public GameObject mainMenuUI;
    public GameObject panel;
    public Sprite textSprite;
    public Sprite noText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void RestartLevel()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (pauseMenu.activeSelf == true)
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        } else if (pauseMenu.activeSelf == false)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void StartGame()
    {
        Cursor.visible = false;
        RestartLevel();    
    }

    public void ControlScreenToggle()
    {  
        
        if (controlMenu.activeSelf == false)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                panel.GetComponent<Image>().sprite = noText;
            }
            controlMenu.SetActive(true);
            mainMenuUI.SetActive(false);
        } else if (controlMenu.activeSelf == true)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                panel.GetComponent<Image>().sprite = textSprite;
            }
            controlMenu.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }
}
