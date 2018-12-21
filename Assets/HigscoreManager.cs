using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class HigscoreManager: MonoBehaviour {
    public static int highscore;
    public Text Score;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        Score.text = highscore + " points";
    }


}
