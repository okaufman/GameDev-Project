using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour
{


    public Text PointText;
    public static int UIpts = 0;


    // Update is called once per frame
    void Update()
    {


        PointText.text = "Score: " + UIpts.ToString();

    }
    private void OnDestroy()
    {
        if (HigscoreManager.highscore < UIpts)
        {
            HigscoreManager.highscore = UIpts;
        }

    }
}
