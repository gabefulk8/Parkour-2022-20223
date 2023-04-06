using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerLobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Playermodel;

    void Start()
    {
        Playermodel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            Playermodel.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Lobby")
        {
            Playermodel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
