using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyIInvisible : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;
    public bool once = true;

    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    private void Update()
    {
        if (this.isActiveAndEnabled)
        {
            //print("active");
            if (once == true)
            {
                target = GameObject.FindWithTag("Player");

                transform.LookAt(target.transform);
                transform.right = target.transform.position - transform.position;

                print("SHOOTING");
                once = false;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        else
        {
           // print("INactive");
            once = true;
        }
        
    }

}
