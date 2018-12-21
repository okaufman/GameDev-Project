using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public UIKeys Keys;
    void Start()
    {

    }


    // Update is called once per frame
    void Update () {
        Keys.allKeys += destroy;
    }
    private void destroy()
    {

        gameObject.SetActive(false);
    }

}
