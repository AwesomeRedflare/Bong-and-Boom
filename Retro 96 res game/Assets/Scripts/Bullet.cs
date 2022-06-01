using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public GameObject greyParticle;

    private void Start()
    {
        rb.velocity = transform.up * speed;

        Invoke("SpawnParticle", 5f);
        Destroy(gameObject, 5f);
    }

    void SpawnParticle()
    {
        Instantiate(greyParticle, transform.position, Quaternion.identity);
    }
}
