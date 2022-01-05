using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PowerUpCars : MonoBehaviour
{
    private float count;
    private float timer;
    private bool isTriggered;
    public float freezeSeconds;
    public GameObject child;
    // Start is called before the first frame update

    private void Update()
    {
        if (isTriggered)
        {
            NewWaypointProgressTracker.isDriving = false;
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                count += 1;
                timer = 0;
            }
            if (freezeSeconds <= count)
            {
                NewWaypointProgressTracker.isDriving = true;
                //isTriggered = false;
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Player")
        {
            Destroy(child);
            isTriggered = true;
        }
    }
}