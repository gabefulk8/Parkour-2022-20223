using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
    [SerializeField] int timer;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
