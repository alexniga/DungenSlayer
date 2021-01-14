using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosiveEnemy : MonoBehaviour
{
    private float speed = 1;
    private Transform player;
    private float radius;
    private Slider slider;
    private Text text;
    public GameObject grenadePrefab;
    private int val;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
        text = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Vector2 objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        float distancePlayer = Vector2.Distance(objPos, playerPos);
        Vector3 boxSize = gameObject.GetComponent<Collider2D>().bounds.size;
        float radius = boxSize.x / 2;

        if (distancePlayer <= radius * 3)
        {
            Debug.Log(slider.value);
            slider.value -= 30f;
            Debug.Log(slider.value);
            text.text = slider.value.ToString() + " / 100";
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            val = Random.Range(1, 100);
            Debug.Log(val);
            if (val < 40)
            {
                Instantiate(grenadePrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    
}
