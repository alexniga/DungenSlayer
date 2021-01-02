using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGold : MonoBehaviour
{
    public Text text;
    private System.Random random;
    // Start is called before the first frame update
    private void Start()
    {
        random = new System.Random();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("asd");
        if (other.gameObject.CompareTag("Gold"))
        {
            other.gameObject.SetActive(false);
            text.text = (Int32.Parse(text.text) + random.Next(1,50)).ToString();
        }
    }
}
