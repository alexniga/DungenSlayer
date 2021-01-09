using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletPrefab;
    public bool shopOpened;

    private float bulletForce;
    private Text attackValue;

    public float attackTimer;
    private float currentAttackTimer;
    private bool canAttack;


    private void Start()
    {
        attackValue = GameObject.FindGameObjectWithTag("DamageValue").GetComponent<Text>();
        bulletForce = 100f;
        attackTimer = 0.35f;
        currentAttackTimer = attackTimer;
        shopOpened = false;
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Shoot();
    }

    void Shoot()
    {
        
        currentAttackTimer += Time.deltaTime;
        if(attackTimer < currentAttackTimer)
        {
            canAttack = true;
        }
        if (Input.GetButton("Fire1"))
        {
            if (canAttack && !shopOpened)
            {
                canAttack = false;
                currentAttackTimer = 0f;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Bullet>().bulletDamage = int.Parse(attackValue.text);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }

}
