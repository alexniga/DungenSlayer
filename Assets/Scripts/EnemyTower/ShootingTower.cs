﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;
    public bool once = true;

    private GameObject target;
    float atackSpeedTime = 2f;

    private void Update()
    {
       
        target = GameObject.FindWithTag("Player");

        transform.LookAt(target.transform);
        transform.right = target.transform.position - transform.position;

        atackSpeedTime -= Time.deltaTime;
        if (atackSpeedTime <= 0f)
        {
            print("SHOOTING");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            atackSpeedTime = 2f;
        }
       

    }
}