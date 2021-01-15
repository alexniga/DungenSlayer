using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public HealthBarEnemy healthBar;
    public GameObject fire;
    float health;
    private List<int> start;
    private List<int> end;
    private List<bool> state;
    private int val;

    private void Start()
    {
        healthBar.SetMaxHealth(300);
        healthBar.SetHealth(300);
        health = 2000;
        val = 200;
        for(int i = 0; i < 20; i++)
        {
            start.Add(i * val);
            end.Add(i * val + val);
            state.Add(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("INAMIC LOVIT");

        if (collision.collider.tag == "Bullet")
        {
            //print("INAMIC LOVIT DE GLONT!");
            health -= 40;
            healthBar.SetHealth(health);
            for (int i = 0; i < 20; i++)
            {
                if(health>=start[i] && health<end[i] && state[i] == true)
                {
                    state[i] = false;
                    fire.SetActive(true);
                }
            }
        }

        if (health <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }
}
