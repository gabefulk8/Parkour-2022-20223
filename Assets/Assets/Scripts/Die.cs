using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Die : MonoBehaviour
{
    public GameObject UI;
    public GameObject DeathCube;
    public GameObject deathText;

    float deathDist = 1000f;

    void Start()
    {

    }

    void Update()
    {
        deathDist = this.transform.position.x - DeathCube.transform.position.x;

        if (deathDist <= .7)
        {
            Debug.Log("blicked");
            UI.GetComponent<UIManager>().ToMainMenu();
        }

        deathText.GetComponent<TextMeshProUGUI>().text = "Death Distance: " + Mathf.Round(deathDist);
    }
}
