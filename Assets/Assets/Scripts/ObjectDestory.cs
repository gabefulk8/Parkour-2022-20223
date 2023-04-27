using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
    GameObject deathField;

    private void Start()
    {
        deathField = GameObject.Find("DeathCube");
    }
    void Update()
    {
        if (deathField.transform.position.x > this.transform.position.x + 100)
        {
            DestroyObject();
        }
    }
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
