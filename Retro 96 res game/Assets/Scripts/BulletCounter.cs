using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    public int bulletCount;

    public Image[] bullets;

    public Player player;

    private void Update()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if(i < bulletCount)
            {
                bullets[i].enabled = true;
            }
            else
            {
                bullets[i].enabled = false;
            }
        }

        bulletCount = player.bulletCount;
    }
}
