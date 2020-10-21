using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakesDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public Image healthBar;
    private float maxHealth;
    private float height;
    private void Start()
    {
        maxHealth = healthBar.rectTransform.sizeDelta.x;
        height = healthBar.rectTransform.sizeDelta.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log(health.rectTransform.sizeDelta);
            float width = healthBar.rectTransform.sizeDelta.x;
            
            if(width > 0)
            {
                Debug.Log("Hit");
                healthBar.rectTransform.sizeDelta = new Vector2(width - 0.1f * maxHealth, height);
            } else
            {
                Debug.Log("Dead");
            }
        }
    }
}
