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
            print("active");
            if (once == true)
            {
               target = GameObject.FindWithTag("Player");
               // targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
               // targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
               //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
                /*
                var targetPosition = target.transform.position;
                targetPosition.y = transform.position.y;
                transform.LookAt(targetPosition);
                */
                print("SHOOTING");
                once = false;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            print("INactive");
            once = true;
        }
        
    }
    /*
    public void TimeToShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void Start()
    {
        InvokeRepeating("TimeToShoot", 0f, 1f);
    }
    */
}
