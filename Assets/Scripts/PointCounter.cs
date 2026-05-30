using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public Sprite filledStar;
    public Image[] stars;

    public EndLevel endLevel;

    public static int index = 0;

    public void Start()
    {
        index=0;
    }

    public void UpdateStars()
    {
        stars[index++].sprite = filledStar;
        if(index == 3)
        {
            endLevel.waitTime = 0;
        }
    }
    
}
