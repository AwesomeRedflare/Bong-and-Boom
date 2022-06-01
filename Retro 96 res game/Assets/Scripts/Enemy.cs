using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public GameObject WhiteParticle;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Enemy");

            Score.scoreAmount++;
            Destroy(col.gameObject);
            Instantiate(WhiteParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
