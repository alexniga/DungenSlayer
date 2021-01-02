using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool shopOpened;

    private float bulletForce = 100f;
    public Text attackValue;

    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;


    private void Start()
    {
        currentAttackTimer = attackTimer;
        shopOpened = false;
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
                Debug.Log(attackTimer);
                canAttack = false;
                currentAttackTimer = 0f;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Bullet>().bulletDamage = float.Parse(attackValue.text);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }

}
