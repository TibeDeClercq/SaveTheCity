using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbageDestroy : MonoBehaviour
{
    public Text countText;
    private float count = 0.0f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = float.Parse(countText.text);
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            count += 1;
            timer = 0;
        }
        countText.text = count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Garbage")
        {
            countText.text = (count - 5).ToString();
            Destroy(other.gameObject);
        }
    }
}
