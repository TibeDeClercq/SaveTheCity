using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public float rotationSpeed = 370;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(rotationSpeed,0,0));
    }
}
