﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneHealth : MonoBehaviour
{
    public HealthBarEnemy healthBar;
    float health;
    private System.Random random;
    public GameObject healthPrefab;
    private int val;
    public GameObject boostPrefab;

    public GameObject goldPrefab;


    private void Start()
    {
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(100);
        health = 100;
        random = new System.Random();
    }

    private void Update()
    {
        val = random.Next(1, 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("INAMIC LOVIT");
        print(collision);
        if (collision.collider.tag == "Bullet")
        {
            Player player = new Player();
            player.LoadPlayer();
            health -= player.AttackDamage;
            healthBar.SetHealth(health);
        }
        

        if (health <= 0)
        {
            val = Random.Range(1, 100);
            Debug.Log(val);
            if (val < 30)
            {
                Instantiate(healthPrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            val = Random.Range(1, 100);
            Debug.Log(val);
            if (val < 30)
            {
                Instantiate(boostPrefab, gameObject.transform.position, gameObject.transform.rotation);
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
