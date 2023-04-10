using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerLobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Playermodel;
    [SerializeField] GameObject[] spawnLocations = new GameObject[4];
    private bool foundPoints = false;
    private Transform[] spawnTransforms = new Transform[4];
    [SerializeField] Transform playerTransform;

    void Start()
    {
        Playermodel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            if(Playermodel.activeSelf == false)
            {
                Playermodel.SetActive(true);

                /*
                if (foundPoints == false)
                {
                    Debug.Log("Penis");
                    spawnLocations[0] = GameObject.Find("Spawn 1");
                    spawnLocations[1] = GameObject.Find("Spawn 2");
                    spawnLocations[2] = GameObject.Find("Spawn 3");
                    spawnLocations[3] = GameObject.Find("Spawn 4");
                    foundPoints = true;
                }
                

                SpawnCharacter();
                */
            }
        }
        else if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (Playermodel.activeSelf == true)
            {
                Playermodel.SetActive(false);
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            foundPoints = false;
        }
    }

    /*
    void SpawnCharacter()
    {
        for(int i = 0; i < spawnLocations.Length; i++)
        {
            spawnTransforms[i] = spawnLocations[i].GetComponent<Transform>();
        }

        playerTransform = spawnTransforms[Random.Range(0, 4)];

    }
    */
}
