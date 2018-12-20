using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Transform player_red;
    public Transform player_blue;

    // Update is called once per frame
    void LateUpdate () {
        if (player.gameObject.activeSelf) {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        if (player_red.gameObject.activeSelf) {
            transform.position = new Vector3(player_red.position.x, player_red.position.y, transform.position.z);
        }
        if (player_blue.gameObject.activeSelf) {
            transform.position = new Vector3(player_blue.position.x, player_blue.position.y, transform.position.z);
        }
    }
}
