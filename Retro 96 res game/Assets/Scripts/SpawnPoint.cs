using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float rotateSpeed = 100f;

    public float speed;

    public bool check;

    public Transform pointOne;
    public Transform pointTwo;

    private void Start()
    {
        rotateSpeed = rotateSpeed += Random.Range(-10f, 10f);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        if (check)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointOne.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, pointOne.position) < .1f)
            {
                check = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointTwo.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointTwo.position) < .1f)
            {
                check = true;
            }
        }

    }
}
