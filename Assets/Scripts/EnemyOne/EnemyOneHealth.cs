using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneHealth : MonoBehaviour
{
    public HealthBarEnemy healthBar;
    float health;

    private void Start()
    {
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(100);
        health = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("INAMIC LOVIT");

        if (collision.collider.tag == "Bullet")
        {
            print("INAMIC LOVIT DE GLONT!");
            health -= 20;
            healthBar.SetHealth(health);
        }
    }
}
