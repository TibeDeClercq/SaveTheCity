using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    void Update()
    {
        float shoot = Input.GetAxis("Fire1");

        if (shoot == 1 && timer >= shootRate)
        {
            GameObject newProjectile = Instantiate(Projectile, transform.position+transform.forward + new Vector3(0,0.5f,0), transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.VelocityChange);
            start = true;
            timer = 0f;
        }
        if (start)
        {
            if (timer < shootRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = shootRate;
                start = false;
            }
        }
    }
}
