using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float timeBtwnBullet;
    public float minExtraWait;
    public float maxExtraWait;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public bool spawn;

    public GameObject bulletDrop;

    private void Start()
    {
        StartCoroutine("SpawnBulletDrops");
    }

    IEnumerator SpawnBulletDrops()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(timeBtwnBullet + Random.Range(-minExtraWait, maxExtraWait));

            Vector2 bullestSpawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            Instantiate(bulletDrop, bullestSpawnPos, Quaternion.identity);
        }
    }
}
