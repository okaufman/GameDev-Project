using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class UIKeys : MonoBehaviour {
    public int totalKeys = 5;
    public static int KeysFound = 0;
    public Text KeyText;
    public event Action allKeys = delegate { };


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        KeyText.text = "Keys: " + KeysFound.ToString() + "/"+  totalKeys;
        if (UIKeys.KeysFound >= 5)
        {
            allKeys();
        }
    }

    
}
