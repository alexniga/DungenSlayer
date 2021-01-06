using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    private float speed = 1;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
        Vector3 boxSize = collider.bounds.size;
        radius = boxSize.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Vector2 objPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector3 boxSize = gameObject.GetComponent<Collider2D>().bounds.size;
        float radius = boxSize.x / 2;

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float distancePlayer = Vector2.Distance(objPos, playerPos);
        if (distancePlayer <= radius * 3)
        {
            text.text = (int.Parse(text.text) + buffValue).ToString();
            gameObject.SetActive(false);
            //Debug.Log("clicked");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
