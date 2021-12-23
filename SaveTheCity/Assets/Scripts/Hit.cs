using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audioClip;
    public GameObject explosionParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Projectile")
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
