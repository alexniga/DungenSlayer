using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakesDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Text text;
    private float maxHealth;

    private void Start()
    {
        maxHealth = 100f;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            if(slider.value > 0)
            {
                Debug.Log("Hit");
                slider.value = slider.value - 10;
                
            } else
            {
                Debug.Log("Dead");

            }
            text.text = slider.value.ToString() + " / 100";
        }
    }
}
