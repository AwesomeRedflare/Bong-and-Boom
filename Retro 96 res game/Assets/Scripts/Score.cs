using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int scoreAmount;

    private Text scoreText;
    public Text finalScoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
        finalScoreText.text = "Score: " + scoreAmount;
    }
}
