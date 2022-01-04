using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = this.gameObject.transform.position.x;
            float y = this.gameObject.transform.position.y;
            float xMouse = Input.mousePosition.x;
            float yMouse = Input.mousePosition.y;
            if(xMouse > x-80 && xMouse < x+80 && yMouse > y-15 && yMouse < y+15)
                SceneManager.LoadScene(this.name);
        }
    }
}
