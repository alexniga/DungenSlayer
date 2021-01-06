using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakesDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Text text;
    public Text damageReduction;
    //private float maxHealth;

    private void Start()
    {
        //maxHealth = 100f;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject bullet = collision.gameObject;
        if (bullet.CompareTag("BulletEnemy"))
        {
            float bulletDamage = bullet.GetComponent<Bullet>().bulletDamage;
            if (slider.value > 0)
            {
                Debug.Log("Hit");
                slider.value = slider.value - bulletDamage * (100f - float.Parse(damageReduction.text)) / 100;

            }
            else
            {
                Debug.Log("Dead");

            }
            text.text = slider.value.ToString() + " / 100";
        }
        
    }
}
