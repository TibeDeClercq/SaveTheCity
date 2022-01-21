using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbageDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garbage")
        {
            Timer.TimerValue += 5;
            Destroy(other.gameObject);
        }
    }
}
