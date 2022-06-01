using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject ControlPanel;

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Invoke("Game", Random.Range(.9f, 1.1f));
    }

    public void OpenControls()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        MainMenuPanel.SetActive(false);
        ControlPanel.SetActive(true);
    }

    public void CloseControls()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        MainMenuPanel.SetActive(true);
        ControlPanel.SetActive(false);
    }

    void Game()
    {
        SceneManager.LoadScene("Game");
    }
}
