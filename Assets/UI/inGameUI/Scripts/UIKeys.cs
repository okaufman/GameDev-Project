using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIKeys : MonoBehaviour {
    public int totalKeys = 5;
    public static int KeysFound = 0;
    public Text KeyText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        KeyText.text = "Keys: " + KeysFound.ToString() + "/"+  totalKeys;
    }
}
