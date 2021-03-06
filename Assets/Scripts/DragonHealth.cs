﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonHealth : MonoBehaviour
{
    public HealthBarEnemy healthBar;
    public GameObject fire;
    float health;
    private List<int> start;
    private List<int> end;
    private List<bool> state;
    private int val;
    private int nr;
    private DateTime timer;
    private int opened;
    private string nextLevelName;
    private string currentLevelName;

    private void Start()
    {
        
        nr = 10;
        health = nr * 300;
        val = nr * 30;
        start = new List<int>();
        end = new List<int>();
        state = new List<bool>();
        healthBar.SetMaxHealth(health);
        healthBar.SetHealth(health);
        for (int i = 0; i < nr - 1; i++)
        {
            start.Add(i * val);
            end.Add(i * val + val);
            state.Add(true);
        }
        /*for (int i = 0; i < nr - 1; i++)
        {
            print(start[i]);
            print(end[i]);
            print(state[i]);
        }*/

    }

    private void Update()
    {
        if (opened==1 && (timer - DateTime.UtcNow).TotalSeconds < 0)
        {
            opened = 2;
            fire.GetComponent<Collider2D>().enabled = true;
            fire.GetComponent<SpriteRenderer>().color= Color.red;
            timer = DateTime.UtcNow.AddSeconds(1);
            //print(opened);
            
        }
        if (opened == 2 && (timer - DateTime.UtcNow).TotalSeconds < 0)
        {
            opened = 0;
            fire.SetActive(false);
        }

        if (health <= 0)
        {
            print("AM INTRAT AICI");
            currentLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().CurrentLevel();
            nextLevelName = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().IncreaseLevel();
            Destroy(gameObject);
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(currentLevelName);
        }
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

            for (int i = 0; i < nr; i++)
            {
                if (health>=start[i] && health<end[i] && state[i] == true)
                {
                    
                    state[i] = false;
                    fire.SetActive(true);
                    opened = 1;
                    timer = DateTime.UtcNow.AddSeconds(1);
                    fire.GetComponent<SpriteRenderer>().color = new Color(1f,1f,0f,0.2f);
                    fire.GetComponent<Collider2D>().enabled = false;
                    break;
                }
            }
            
        }
       
    }
    public void GrenadeDamage()
    {
        health -= 50;
        healthBar.SetHealth(health);
    }
}
