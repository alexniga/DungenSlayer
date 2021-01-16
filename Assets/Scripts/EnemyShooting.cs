using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 100f;

    public float attackTimer = 0.7f;
    private float currentAttackTimer;
    private bool canAttack;

    private void Start()
    {
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
    }

    void Shoot()
    {

        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }
        
        if (canAttack)
        {
            canAttack = false;
            attackTimer = 0f;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().bulletDamage = 30;
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }
}
