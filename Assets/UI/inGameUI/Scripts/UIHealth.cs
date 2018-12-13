using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
    public Image healthBar;
    public static int health =100;
   public float maxHealth = 100.0f;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();

		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / maxHealth;
	}
}
