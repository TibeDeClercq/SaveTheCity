using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;
using static MyGameManager;

public class Resume : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = this.gameObject.transform.position.x;
            float y = this.gameObject.transform.position.y;
            float xMouse = Input.mousePosition.x;
            float yMouse = Input.mousePosition.y;
            if (xMouse > x - 70 && xMouse < x + 70 && yMouse > y - 15 && yMouse < y + 15)
            {
                MyGameManager.gameState = GameStates.Playing;
                Timer.IsActive = true;
                NewWaypointProgressTracker.isDriving = true;
                FirstPersonController.isWalking = true;
                Player.GetComponent<Shoot>().enabled = true;
            }
                
        }
    }
}
