using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var rotation = transform.rotation;
        rotation.x = 0;
        rotation.y = 0;
        rotation.z = 0;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
