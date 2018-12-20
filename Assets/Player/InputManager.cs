using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

    public event Action PAttack = delegate { };
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject player_blue;
    [SerializeField]
    private GameObject player_red;


    private float temp_x;
    private float temp_y;
    private float temp_z;
    private int[] isActive = new int[] {1, 0, 0};

    private void Start() {
        player.SetActive(true);
        player_red.SetActive(false);
        player_blue.SetActive(false);
        temp_x = player.transform.position.x;
        temp_y = player.transform.position.y;
        temp_z = player.transform.position.z;
    }

    void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            PAttack(); 
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            switch (GetIndexPlayerActive()) {
                case 0:
                    // do nothing
                    break;
                case 1:
                    SetPlayerInactive(player_red);
                    isActive[0] = 1;
                    PositionNewPlayer(player);
                    
                    break;
                case 2:
                    SetPlayerInactive(player_blue);
                    isActive[0] = 1;
                    PositionNewPlayer(player);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            switch (GetIndexPlayerActive()) {
                case 0:
                    SetPlayerInactive(player);
                    
                    isActive[1] = 1;
                    PositionNewPlayer(player_red);
                    break;
                case 1:
                    // do nothing
                    break;
                case 2:
                    SetPlayerInactive(player_blue);
                    isActive[1] = 1;
                    PositionNewPlayer(player_red);
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            switch (GetIndexPlayerActive()) {
                case 0:
                    SetPlayerInactive(player);
                    isActive[2] = 1;
                    PositionNewPlayer(player_blue);
                    break;
                case 1:
                    SetPlayerInactive(player_red);
                    isActive[2] = 1;
                    PositionNewPlayer(player_blue);
                    break;
                case 2:
                    // do nothing
                    break;
            }
        }
    }

    public int GetIndexPlayerActive() {
        for (int i = 0; i < isActive.Length; i++) {
            if (isActive[i] == 1) {
                return i;
            }
        }
        return -1;
    }

    public void SetPlayerInactive(GameObject go) {
        temp_x = go.transform.position.x;
        temp_y = go.transform.position.y;
        go.SetActive(false);
        for (int i = 0; i < isActive.Length; i++) {
            isActive[i] = 0;
        }
    }

    public void PositionNewPlayer(GameObject go) {
        go.SetActive(true);
        go.transform.position = new Vector3(temp_x, temp_y, temp_z);
    }
}
