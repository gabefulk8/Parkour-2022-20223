using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadetoBlack : MonoBehaviour
{
    [SerializeField] GameObject Black;
    [SerializeField] GameObject Player;
    private Image black2;
    [SerializeField] int deathY;
    [SerializeField] int deathPlaneDistance;
    private float playery;
    private byte imageAlpha;
    // Start is called before the first frame update
    void Start()
    {
        black2 = Black.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        playery = Player.GetComponent<Transform>().position.y;
        if (playery > (deathY + deathPlaneDistance)) black2.color = new Color32(0, 0, 0, 0);
        else if (playery <= (deathY + deathPlaneDistance) && playery >= deathY)
        {
            fade(deathPlaneDistance, playery, deathY);
        }
        else if (playery < deathY)
        {
            black2.color = new Color32(255, 255, 255, 255);
        }
    }

    void fade(int difVar, float playerVar, int bottomVar)
    {
        imageAlpha = (byte)(((difVar - playerVar + bottomVar) / difVar) * 256);
        black2.color = new Color32(255, 255, 255, imageAlpha);
    }

}


