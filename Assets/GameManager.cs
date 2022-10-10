using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] modules;
    private GameObject size;
    private GameObject currentmodule;
    private GameObject newmodule;
    public GameObject startingmodule;
    private float xlength;
    private float ylength;
    private float ylength2;
    private float xposition;
    private float yposition;

    // Start is called before the first frame update
    void Start()
    {
        currentmodule = startingmodule;
        InvokeRepeating("SpawnModule", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnModule()
    {
        int whichModule = Random.Range(0, modules.Length);
        print(whichModule);
        size = modules[whichModule];
        xlength = currentmodule.GetComponent<Renderer>().bounds.size.x;
        //ylength = currentmodule.GetComponent<Renderer>().bounds.size.y;
        xposition = currentmodule.GetComponent<Transform>().position.x;
        //yposition = currentmodule.GetComponent<Transform>().position.y;
        //ylength2 = size.GetComponent<Renderer>().bounds.size.y;


        newmodule = Instantiate(modules[whichModule], new Vector3(xposition + xlength, 0, 0), Quaternion.Euler(0, 0, 0));

        currentmodule = newmodule;
    }
}
