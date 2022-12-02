using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pregeneration : MonoBehaviour
{
    [SerializeField] GameObject[] startmodules;
    [SerializeField] GameObject[] trainmodules;
    [SerializeField] GameObject[] indoormodules;
    [SerializeField] GameObject[] rooftopmodules;
    [SerializeField] GameObject[] traintoroof;
    [SerializeField] GameObject[] traintoindoor;
    [SerializeField] GameObject[] indoortotrain;
    [SerializeField] GameObject[] indoortoroof;
    [SerializeField] GameObject[] rooftotrain;
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
    public float deathSpeed = 1.5f;
    int timerDD = 0;
    
    void Start()
    {
        whichTheme = 2;
        repeat = -1;
        goOn = true;
        currentmodule = startingmodule;
        Invoke("SpawnModule", 0f);
        InvokeRepeating("increaseDeathSpeed", 7, 7);
      
    }

    void Update()
    {
        
        
        if (timerDD == 60)
        {
            if (Time.timeScale == 1)
            {
                deathPlane.transform.position += new Vector3(deathSpeed, 0, 0);
            }
            //Debug.Log(deathSpeed + ", " + deathPlane.transform.position.x);
            timerDD = 0;
        }
        timerDD++;
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
                case 0://train
                    switch (startPoint)//check next module type
                    {
                        case 1://indoor
                            whichModule = Random.Range(0, traintoindoor.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(traintoindoor[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("indoorspawn", 3f, 3f);
                            break;
                        case 2://rooftop
                            whichModule = Random.Range(0, traintoroof.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(traintoroof[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("rooftopspawn", 3f, 3f);
                            break;
                    }
                    break;
                case 1://indoor
                    switch (startPoint)//determine next module type
                    {
                        case 0://train
                            whichModule = Random.Range(0, indoortotrain.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(indoortotrain[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("trainspawn", 3f, 3f);
                            break;
                        case 2://rooftop
                            whichModule = Random.Range(0, indoortoroof.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(indoortoroof[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("rooftopspawn", 3f, 3f);
                            break;
                    }
                    break;
                case 2://rooftop
                    switch (startPoint)//determine next module type
                    {
                        case 0://train
                            whichModule = Random.Range(0, rooftotrain.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(rooftotrain[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("trainspawn", 3f, 3f);
                            break;
                        case 1://indoor
                            whichModule = Random.Range(0, rooftoindoor.Length);
                            endpoint = currentmodule.GetChild(1).position;
                            newmodule = Instantiate(rooftoindoor[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
                            currentmodule = newmodule.transform;
                            //print("spawned: " + newmodule);
                            InvokeRepeating("indoorspawn", 3f, 3f);
                            break;
                    }
                    break;
            }
        }
    }

    void trainspawn()
    {
        whichModule = Random.Range(0, trainmodules.Length);
        if (whichModule == repeat) goOn = false;
        while (whichModule == repeat)
        {
            whichModule = Random.Range(0, trainmodules.Length);
            if (whichModule != repeat) goOn = true;
        }

        if(goOn == true)
        {
            endpoint = currentmodule.GetChild(1).position;
            newmodule = Instantiate(trainmodules[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
            currentmodule = newmodule.transform;
            repeat = whichModule;
            mCounter++;

            //print("spawned: " + newmodule);

            if (whichModule == 0 && mCounter >= 3)
            {
                variableReset(0);
                Invoke("SpawnModule", 3f);
                CancelInvoke("trainspawn");
            }
        }
    }

    void indoorspawn()
    {
        whichModule = Random.Range(0, indoormodules.Length);
        if (whichModule == repeat) goOn = false; 
        while (whichModule == repeat)
        {
            whichModule = Random.Range(0, trainmodules.Length);
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
                Invoke("SpawnModule", 3f);
                CancelInvoke("indoorspawn");
            }
        }
    }

    void rooftopspawn()
    {
        whichModule = Random.Range(0, rooftopmodules.Length);
        if (whichModule == repeat) goOn = false;
        while (whichModule == repeat)
        {
            whichModule = Random.Range(0, trainmodules.Length);
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
                Invoke("SpawnModule", 3f);
                CancelInvoke("rooftopspawn");
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
        deathSpeed = 1.5f;
    }

    void increaseDeathSpeed()
    {
        if (deathSpeed >= 4)
        {
            deathSpeed = 4;
        } else
        {
            deathSpeed *= 1.1f;
        }
    }
}
