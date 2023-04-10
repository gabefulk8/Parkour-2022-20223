using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] Canvas pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Practice")
        {
            if (Input.GetKeyUp(KeyCode.P) && isPaused == false) PauseGame();

            else if (Input.GetKeyUp(KeyCode.P) && isPaused == true) UnPauseGame();
            
            
        }   
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.GetComponent<Canvas>().enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void loadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
