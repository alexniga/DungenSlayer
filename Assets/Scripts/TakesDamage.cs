using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakesDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private Text healthText;

    private Text damageReduction;
    //private float maxHealth;

    private void Start()
    {
        //slider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
        //healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        //damageReduction = GameObject.FindGameObjectWithTag("ArmorValue").GetComponent<Text>();
        //maxHealth = 100f;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Spike"))
        {
            Debug.Log("spike");
        }
        /*if (obj.CompareTag("BulletEnemy"))
        {
            float bulletDamage = obj.GetComponent<Bullet>().bulletDamage;
            if (slider.value > 0)
            {
                Debug.Log("Hit");
                slider.value = slider.value - bulletDamage * (100f - float.Parse(damageReduction.text)) / 100;

            }
            else
            {
                Debug.Log("Dead");

            }
            healthText.text = slider.value.ToString() + " / 100";
        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Spike"))
        {
            Debug.Log("spike");
        }
    }
}
