using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveEnemyControledRandom : MonoBehaviour
{

    public float movingTime = 3f;
    public float speed = 2f;
    public float distanceToMove = 1f;
    float movingTimer;

    float limitUpY = 3.5f;
    float limitDownY = -3.5f;

    float limitLeftX = -6f;
    float limitRightX = 6f;

    Vector2 lastPosition;

    public GameObject obj;

    private bool canFade;
    private Color alphaColor;
    private float timeToFade = 1.0f;

    private void Start()
    {
        movingTimer = movingTime;
        lastPosition = transform.position;

        movingTime = 5f;
        speed = 0.7f;
        distanceToMove = 2f;
    }

    private void Update()
    {
        movingTimer -= Time.deltaTime;

        if (movingTimer <= 0)
        {
            movingTimer = movingTime;
            StartCoroutine(FadeTo(0.0f, 0.5f));
            StartCoroutine("MoveTheEnemy");// MoveTheEnemy();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }

    IEnumerator MoveTheEnemy()
    {

        Vector2 target = CalculateEnemyNewPosition();
        
        while (Vector2.Distance(transform.position, target) > 0.001f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            yield return 0;
        }

        StartCoroutine(FadeTo(1.0f, 1.0f));
        lastPosition = transform.position;
    }

    Vector2 CalculateEnemyNewPosition()
    {
        float X = Random.Range(lastPosition.x - distanceToMove, lastPosition.x + distanceToMove);
        X = X > limitLeftX ? X : limitLeftX;
        X = X < limitRightX ? X : limitRightX;

        float Y = Random.Range(lastPosition.y - distanceToMove, lastPosition.y + distanceToMove);
        Y = Y < limitUpY ? Y : limitUpY;
        Y = Y > limitDownY ? Y : limitDownY;

        return new Vector2(X, Y);
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
    }
}

