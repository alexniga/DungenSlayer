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
    private void Start()
    {
        movingTimer = movingTime;
        lastPosition = transform.position;
    }

    private void Update()
    {
        movingTimer -= Time.deltaTime;

        if (movingTimer <= 0)
        {
            movingTimer = movingTime;
            StartCoroutine("MoveTheEnemy");// MoveTheEnemy();
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
}

