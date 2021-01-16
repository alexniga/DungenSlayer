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
        slider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        damageReduction = GameObject.FindGameObjectWithTag("ArmorValue").GetComponent<Text>();
        //maxHealth = 100f;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Spike"))
        {
            Debug.Log("spike");
        }
        if (obj.CompareTag("BulletEnemy"))
        {
            //Debug.Log(slider);
            int bulletDamage = obj.GetComponent<Bullet>().bulletDamage;
            Damage(bulletDamage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Spike"))
        {
            Debug.Log("spike");
            Damage(40);
        }
        if (obj.CompareTag("Fire"))
        {
            Debug.Log("Fire");
            Damage(99999);
        }

    }

    private void Damage(int val)
    {
        slider.value = slider.value - val * (100f - float.Parse(damageReduction.text)) / 100;
        if (slider.value > 0)
        {
            //Debug.Log("Hit");

            healthText.text = slider.value.ToString() + " / 100";
        }
        else
        {
            healthText.text = slider.value.ToString() + " / 100";
            GameObject.FindGameObjectWithTag("Pannels").transform.GetChild(0).gameObject.SetActive(true);
            Player player = new Player();
            player.LoadPlayer();
            player.Money = int.Parse(GameObject.FindGameObjectWithTag("GoldText").GetComponent<Text>().text.ToString());
            player.SavePlayer();
            Debug.Log("Dead");
            Time.timeScale = 0f;

        }
        
    }
}
