using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float speed;

    Vector3 targetPosition;
    Vector3 startPosition;

    bool goDown = false;
    bool goUp = false;

    private void Start()
    {
        startPosition = gameObject.transform.position;
        targetPosition = gameObject.transform.position;
        goDown = true;
        targetPosition.y -= 0.1f;
    }

    private void Update()
    {
        if (goDown == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }

        if (transform.position == targetPosition && startPosition.y > targetPosition.y)
        {
            goDown = false;
            goUp = true;
            targetPosition.y += 0.2f;
        }

        if (goUp == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }

        if (transform.position == targetPosition && startPosition.y < targetPosition.y)
        {
            goDown = true;
            goUp = false;
            targetPosition.y -= 0.2f;
        }

    }
}
