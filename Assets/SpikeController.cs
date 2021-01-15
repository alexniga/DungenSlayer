using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float startValue;
    private float beginValue;
    private float endValue;
    private DateTime timer;
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
        beginValue = 3f;
        endValue = 3f;
        state = true;
        timer = DateTime.UtcNow.AddSeconds(startValue);
    }

    // Update is called once per frame
    void Update()
    {
        if ((timer - DateTime.UtcNow).TotalSeconds <= 0 && state)
        {
            timer = DateTime.UtcNow.AddSeconds(endValue);
            state = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

        if ((timer - DateTime.UtcNow).TotalSeconds <= 1 && !state)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if ((timer - DateTime.UtcNow).TotalSeconds <= 0 && !state)
        {
            timer = DateTime.UtcNow.AddSeconds(beginValue);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<Collider2D>().enabled = true;
            state = true;
        }

    }
       
        
}
