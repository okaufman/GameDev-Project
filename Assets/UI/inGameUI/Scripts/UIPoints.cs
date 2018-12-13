using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour {
    

    public Text PointText;
    public static int UIpts = 0;
   
	
	// Update is called once per frame
	void Update () {
        /*
        GetComponent<GruntBehaviour>().get10Points += UIPoints_get10Points;

        GetComponent<GruntBehaviour>().getPoint += UIPoints_getPoint;

        GetComponent<TEnemyGun>().get10Points += UIPoints_get10Points;

        GetComponent<TEnemyGun>().getPoint += UIPoints_getPoint;

    */

        PointText.text = "Score: "+UIpts.ToString();

    }
    /**
    private void UIPoints_get10Points()
    {
        increasePoints(10);
    }

    private void UIPoints_getPoint()
    {
        increasePoints(1);
    }

    void increasePoints(int amount)
    {
    UIpts += amount;
    }
    */
}
