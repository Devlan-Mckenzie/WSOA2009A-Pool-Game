using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagment_Script : MonoBehaviour
{
    public Text scoreText;
    public Text HighscoreText;
    int score;
    int highscore;

    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        HighscoreText.text = "HighScore: " + highscore;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }

    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


}
