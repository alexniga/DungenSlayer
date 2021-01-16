using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;
    public bool once = true;

    private GameObject target;
    float atackSpeedTime = 1.5f;

    private void Update()
    {
       
        target = GameObject.FindWithTag("Player");

        transform.LookAt(target.transform);
        transform.right = target.transform.position - transform.position;
        
        atackSpeedTime -= Time.deltaTime;
        if (atackSpeedTime <= 0f)
        {
            var rotation = transform.rotation;
            rotation.y = 0;
            //print("SHOOTING");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            atackSpeedTime = 2f;
        }
       

    }
}