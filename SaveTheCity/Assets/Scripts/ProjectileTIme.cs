using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTime : MonoBehaviour
{
    float timer = 0;
    float lifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifeTime)
        {
            timer += Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(timer > 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
