using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    private float count;
    private float pointsCount;
    public Text timer;
    public Text points;
    public AudioClip audioClip;
    public GameObject explosionParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = float.Parse(timer.text);
        pointsCount = float.Parse(points.text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Projectile")
        {
            if (gameObject.tag == "GoodCar")
            {
                Timer.TimerValue -= 10;
            }
            if(gameObject.tag == "BadCar")
            {
                points.text = (pointsCount+1).ToString();
            }
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
