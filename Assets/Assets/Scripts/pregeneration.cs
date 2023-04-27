using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pregeneration : MonoBehaviour
{
    [SerializeField] GameObject[] startmodules;
    [SerializeField] GameObject[] roadmodules;
    [SerializeField] GameObject[] indoormodules;
    [SerializeField] GameObject[] rooftopmodules;
    [SerializeField] GameObject[] roadtoroof;
    [SerializeField] GameObject[] roadtoindoor;
    [SerializeField] GameObject[] indoortoroad;
    [SerializeField] GameObject[] indoortoroof;
    [SerializeField] GameObject[] rooftoroad;
    [SerializeField] GameObject[] rooftoindoor;
    public Transform startingmodule;
    private Transform currentmodule;
    private GameObject newmodule;
    private Vector3 endpoint;
    private int mCounter;
    private int repeat;
    private int whichModule;
    private int whichTheme;
    private int startPoint;
    
    private bool goOn;

    public GameObject deathPlane;
    [SerializeField] private float deathSpeed = 2f;

    [SerializeField] GameObject Black;
    [SerializeField] GameObject Player;
    private Image black2;
    [SerializeField] float deathY;
    [SerializeField] float deathPlaneDistance;
    private float playery;
    private byte imageAlpha;

    public GameObject daVoid;

    void Start()
    {
        black2 = Black.GetComponent<Image>();
        whichTheme = Random.Range(0,2);
        repeat = -1;
        goOn = true;
        currentmodule = startingmodule;
        SpawnModule();
        Invoke("increaseDeathSpeed", 7);
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            deathPlane.transform.position += new Vector3(deathSpeed / 60, 0, 0);
        }
    }

    private void Update()
    {
        playery = Player.GetComponent<Transform>().position.y;
        deathY = currentmodule.position.y - 30;
        deathPlaneDistance = deathY + 10;
        if (playery > (deathPlaneDistance)) black2.color = new Color32(0, 0, 0, 0);
        else if (playery <= (deathPlaneDistance) && playery >= deathY)
        {
            fade(deathPlaneDistance, playery, deathY);
        }
        else if (playery < deathY)
        {
            black2.color = new Color32(0, 0, 0, 255);
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
        }

        daVoid.transform.position = new Vector3(Player.transform.position.x, -100, 15);
    }

    void SpawnModule()
    {
        //choose next module type
        startPoint = Random.Range(0, 3);
        if (startPoint == whichTheme) goOn = false;
        while(startPoint == whichTheme)
        {
            startPoint = Random.Range(0, 3);
            if (startPoint != whichTheme) goOn = true;
        }

        //if the next module type is different move on
        if(goOn == true)
        {
            switch (whichTheme) //check what the last module type was
            {
                case 0://road
                    switch (startPoint)//check next module type
                    {
                        case 1://indoor
                            whichModule = Random.Range(0, roadtoindoor.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(roadtoindoor[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("indoorspawn", 2f, 2f);
                            break;
                        case 2://rooftop
                            whichModule = Random.Range(0, roadtoroof.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(roadtoroof[whichModule], endpoint, Quaternion.Euler(0, 180, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("rooftopspawn", 2f, 2f);
                            break;
                    }
                    break;
                case 1://indoor
                    switch (startPoint)//determine next module type
                    {
                        case 0://road
                            whichModule = Random.Range(0, indoortoroad.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(indoortoroad[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("roadspawn", 2f, 2f);
                            break;
                        case 2://rooftop
                            whichModule = Random.Range(0, indoortoroof.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(indoortoroof[whichModule], endpoint, Quaternion.Euler(0, 180, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("rooftopspawn", 2f, 2f);
                            break;
                    }
                    break;
                case 2://rooftop
                    switch (startPoint)//determine next module type
                    {
                        case 0://road
                            whichModule = Random.Range(0, rooftoroad.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(rooftoroad[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("roadspawn", 2f, 2f);
                            break;
                        case 1://indoor
                            whichModule = Random.Range(0, rooftoindoor.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(rooftoindoor[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("indoorspawn", 2f, 2f);
                            break;
                    }
                    break;
            }
        }
    }

    void roadspawn()
    {
        if (currentmodule.transform.position.x - Player.transform.position.x < 25)
        {
            whichModule = Random.Range(0, roadmodules.Length);
            if (whichModule == repeat) goOn = false;
            while (whichModule == repeat)
            {
                whichModule = Random.Range(0, roadmodules.Length);
                if (whichModule != repeat) goOn = true;
            }

            if (goOn == true)
            {
                endpoint = currentmodule.GetChild(1).position;
                newmodule = Instantiate(roadmodules[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                currentmodule = newmodule.transform;
                repeat = whichModule;
                mCounter++;

                //print("spawned: " + newmodule);

                if (whichModule == 0 && mCounter >= 3)
                {
                    variableReset(0);
                    Invoke("SpawnModule", 2f);
                    CancelInvoke("roadspawn");
                }
            }
        }
    }

    void indoorspawn()
    {
        if (currentmodule.transform.position.x - Player.transform.position.x < 25)
        {
            whichModule = Random.Range(0, indoormodules.Length);
            if (whichModule == repeat) goOn = false;
            while (whichModule == repeat)
            {
                whichModule = Random.Range(0, roadmodules.Length);
                if (whichModule != repeat) goOn = true;
            }

            if (goOn == true)
            {
                endpoint = currentmodule.GetChild(1).position;
                newmodule = Instantiate(indoormodules[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                currentmodule = newmodule.transform;
                repeat = whichModule;
                mCounter++;

                //print("spawned: " + newmodule);

                if (whichModule == 0 && mCounter >= 3)
                {
                    variableReset(1);
                    Invoke("SpawnModule", 2f);
                    CancelInvoke("indoorspawn");
                }
            }
        }
    }

    void rooftopspawn()
    {
        if (currentmodule.transform.position.x - Player.transform.position.x < 25)
        {
            whichModule = Random.Range(0, rooftopmodules.Length);
            if (whichModule == repeat) goOn = false;
            while (whichModule == repeat)
            {
                whichModule = Random.Range(0, roadmodules.Length);
                if (whichModule != repeat) goOn = true;
            }

            if (goOn == true)
            {
                endpoint = currentmodule.GetChild(1).position;
                newmodule = Instantiate(rooftopmodules[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                currentmodule = newmodule.transform;
                repeat = whichModule;
                mCounter++;

                //print("spawned: " + newmodule);

                if (whichModule == 0 && mCounter >= 3)
                {
                    variableReset(2);
                    Invoke("SpawnModule", 2f);
                    CancelInvoke("rooftopspawn");
                }
            }
        }
    }

    //resets all of the variables
    void variableReset(int themevar)
    {
        mCounter = 0;
        repeat = -1;
        whichTheme = themevar;
        goOn = true;
        deathSpeed = 2f;
    }

    void increaseDeathSpeed()
    {
        // player max run speed is 7, player min run speed is 4.5
        // try to have it so that after like 1 min, the max speed of the death wall goes up to 5, after 1.5 min up to 6, after 2 min, up to 7  
            /*
                this could be done by having like 3 dif funciton to set the max speed of deathwall and invoking them all in start after those time periods or something (you can implement however u like tho, there are prob better ways)
                ^ this is probably more for the Versus game mode. 
            
                For the solo endless runner would want the wall's max speed to cap at like 5.5 -> 6 range
            */
        // :)
        
        if (deathSpeed >= 4f)
        {
            deathSpeed = 4f;
        } else
        {
            deathSpeed *= 1.1f;
        }
        Invoke("increaseDeathSpeed", 7);
    }

    void fade(float startFadeY, float playerVar, float deathY)
    {
        imageAlpha = (byte)(  (Mathf.Abs(playerVar) - Mathf.Abs(startFadeY)) / 10 * 256);
        black2.color = new Color32(0, 0, 0, imageAlpha);
    }
}