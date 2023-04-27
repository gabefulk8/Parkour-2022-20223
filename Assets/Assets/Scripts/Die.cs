using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Die : MonoBehaviour
{
    public GameObject UI;
    public GameObject deathText;
    public GameObject deathPlane;
    public GameObject Player;

    float deathDist = 1000f;
    float runDist = 0f;

    void Update()
    {
        runDist = Player.transform.position.x - 55;
        deathDist = this.transform.position.x - deathPlane.transform.position.x;

        if (deathDist <= .7)
        {
            //Debug.Log("blicked");
            UI.GetComponent<UIManager>().ToMainMenu();
        }

        deathText.GetComponent<TextMeshProUGUI>().text = "Distance: " + Mathf.Round(runDist);
    }
}
