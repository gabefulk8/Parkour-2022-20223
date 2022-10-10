using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] modules;
    public Transform startingmodule;
    private Transform currentmodule;
    private GameObject newmodule;
    private Vector3 endpoint;
    public int timer;

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
        endpoint = currentmodule.GetChild(2).position;

        newmodule = Instantiate(modules[whichModule], endpoint, Quaternion.Euler(0, 0, 0));
        currentmodule = newmodule.transform;
    }



}
