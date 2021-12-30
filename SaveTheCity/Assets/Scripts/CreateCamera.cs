using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCamera : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera newCamera = Instantiate(camera, transform.position + transform.forward, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
