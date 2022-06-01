using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject gameOverPanel;
    public GameObject enemySpawner;
    public GameObject bulletSpawner;
    public GameObject WhiteParticle;
    public Text waveText;

    public float timeBtwnEnemy;
    public float minDifficulty;
    public float maxDifficulty;
    public float LenghtOfWave;
    public float waveCount;
    public float timeBtwnWaves;

    public int waveNumber;

    public bool dead;

    private void Start()
    {
        StartCoroutine("WaveSystem");
    }

    private void Update()
    {
        if (waveCount >= -1 && !dead)
        {
            waveCount -= Time.deltaTime;
        }
    }

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        dead = true;
        Destroy(enemySpawner);
        Destroy(bulletSpawner);
        Destroy(waveText);

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Instantiate(WhiteParticle, transform.position, Quaternion.identity);
            Destroy(e);
        }

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("bullet"))
        {
            Destroy(e);
        }

        foreach (GameObject e in GameObject.FindGameObjectsWithTag("BulletDrop"))
        {
            Destroy(e);
        }

        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    IEnumerator WaveSystem()
    {
        while (dead == false)
        {
            while (waveCount > 0 && enemySpawner.gameObject != null)
            {
                enemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();

                yield return new WaitForSeconds(timeBtwnEnemy);
            }

            if(waveCount <= 0)
            {
                yield return new WaitForSeconds(3);

                foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Instantiate(WhiteParticle, transform.position, Quaternion.identity);
                    Destroy(e);
                }

                waveNumber++;
                waveText.text = "Wave " + waveNumber;
                waveText.gameObject.SetActive(true);

                yield return new WaitForSeconds(timeBtwnWaves);

                waveText.gameObject.SetActive(false);

                if(timeBtwnEnemy > .1f)
                {
                    timeBtwnEnemy = timeBtwnEnemy += Random.Range(-maxDifficulty, -minDifficulty);
                }
                if(timeBtwnEnemy < 0)
                {
                    timeBtwnEnemy = 0.09f;
                }

                LenghtOfWave += 5;
                waveCount = LenghtOfWave;

            }
        }
    }

    public void RestartButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Invoke("Restart", Random.Range(.9f, 1.1f));
    }

    public void GoToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Invoke("MainMenu", Random.Range(.9f, 1.1f));
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
