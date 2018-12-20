using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHealth : MonoBehaviour {
    public Image healthBar;
    public static int health =100;
    public float maxHealth = 100.0f;
    private static int deadCount = 0;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / maxHealth;
        if (deadCount > 2) {
            SceneManager.LoadScene(0);
        }
    }

    public static void IncrementDeadCount() {
        deadCount++;
    }
}
