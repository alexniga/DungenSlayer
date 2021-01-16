using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : CancelableItem
{
    private GameObject grenadeRange;
    private GameObject grenadeArea;
    private Camera cam;

    private Vector2 mousePos;
    private Vector2 playerPos;
    private float distancePlayer;
    private float range = 4.1f;
    private DateTime timer;
    private int state = 0;
    private float radius;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        grenadeArea = GameObject.FindGameObjectWithTag("GranadeArea");
        grenadeArea = GameObject.FindGameObjectWithTag("GranadeRange");
    }

    private void FixedUpdate()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(grenadeRange.transform.position.x, grenadeRange.transform.position.y);
        distancePlayer = Vector2.Distance(mousePos, playerPos);
        grenadeArea.transform.position = new Vector3(mousePos.x, mousePos.y, grenadeArea.transform.position.z);
        if (distancePlayer >= range)
        {
            Debug.Log("Out of range");
            //gameObject.GetComponent<Grenade>().enabled = false;
            isCanceled = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            //Debug.Log("Boom");
            //gameObject.GetComponent<Grenade>().enabled = false;
            //isUsed = true;
            AreaDamageEnemies();
            timer = DateTime.UtcNow.AddSeconds(0);
            state = 1;
        }
        if (state == 1 && (DateTime.UtcNow - timer).TotalSeconds >= 0)
        {
            //Debug.Log("Boom");
            isUsed = true;
            state = 0;
        }
    }

    // Update is called once per frame
    private void OnEnable()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        grenadeArea = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).gameObject;
        grenadeRange = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;
        Vector3 boxSize = grenadeArea.GetComponent<SpriteRenderer>().bounds.size;
        radius = boxSize.x / 2;
        grenadeRange.SetActive(true);
        grenadeArea.SetActive(true);
        
        isCanceled = false;
        isUsed = false;
    }

    private void OnDisable()
    {
        grenadeRange.SetActive(false);
        grenadeArea.SetActive(false);

    }

    void AreaDamageEnemies()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(mousePos, radius);
        var position = grenadeArea.transform.position;
        position.z = 0;
        GameObject obj = Instantiate(explosionPrefab, position, grenadeArea.transform.rotation);
        foreach (Collider2D col in objectsInRange)
        {
            GameObject enemy = col.gameObject;
            if (enemy.CompareTag("Enemy"))
            {
                if (enemy.name.Equals("Enemy"))
                {
                    enemy.GetComponent<EnemyOneHealth>().GrenadeDamage();
                }
                else if (enemy.name.Equals("towerEnemy"))
                {
                    enemy.GetComponent<EnemyTowerHealth>().GrenadeDamage();
                }
                else if (enemy.name.Equals("Dragon"))
                {
                    enemy.GetComponent<DragonHealth>().GrenadeDamage();
                }
                else if (enemy.name.Equals("Enemy2"))
                {
                    Destroy(enemy);
                }

                //Debug.Log(enemy.name);
            }
            

        }
    }
}
