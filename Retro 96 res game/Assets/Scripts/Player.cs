using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;

    public GameObject bullet;
    public int bulletCount;
    public int maxBulletCount;

    public GameObject WhiteParticle;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bulletCount > 0)
        {
            FindObjectOfType<AudioManager>().Play("Shoot");
            bulletCount--;
            Instantiate(bullet, transform.position, transform.rotation);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
        }

        if(bulletCount > maxBulletCount)
        {
            bulletCount = maxBulletCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BulletDrop"))
        {
            FindObjectOfType<AudioManager>().Play("Ammo");
            Destroy(col.gameObject);
            bulletCount++;
        }

        
        if (col.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            Instantiate(WhiteParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("Bounce");
    }
}
