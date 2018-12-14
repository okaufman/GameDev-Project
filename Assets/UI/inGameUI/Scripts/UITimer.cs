using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

    public static float totalTime = 300;
    public Text windowText;
    public Text timerText;
    public float startTime;
    

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        totalTime -= Time.deltaTime;
        string minutes = ((int)totalTime / 60).ToString();
        string seconds = ((int)totalTime % 60).ToString();
        timerText.text = minutes + ":" + seconds;
        if (totalTime<= 0.0f)
        {
            timerEnded();
        }
	}

    void timerEnded()
    {
        windowText.text = "Time is Up";
        print(windowText);
    }
}
