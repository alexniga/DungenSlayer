using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerHealth : MonoBehaviour
{
    public HealthBarEnemy healthBar;
    float health;
    public GameObject shieldPrefab;
    public GameObject goldPrefab;
    private int val;

    private void Start()
    {
        healthBar.SetMaxHealth(300);
        healthBar.SetHealth(300);
        health = 300;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("INAMIC LOVIT");

        if (collision.collider.tag == "Bullet")
        {
            //print("INAMIC LOVIT DE GLONT!");
            Player player = new Player();
            player.LoadPlayer();
            health -= player.AttackDamage;
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            val = Random.Range(1, 100);
            Debug.Log(val);
            if (val < 40)
            {
                Instantiate(shieldPrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            Instantiate(goldPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    public void GrenadeDamage()
    {
        health -= 50;
        healthBar.SetHealth(health);
    }
}
