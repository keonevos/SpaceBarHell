using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private int score = 0;
    private int hightScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "SCORE  : " + score.ToString();
        highscoreText.text = "HIGHSCORE  : " + score.ToString();
    }

    // Update is called once per frame
    public void AddScore(int inputScore)
    {
        score += inputScore;
        scoreText.text = "SCORE  : " + score.ToString();
        highscoreText.text = "HIGHSCORE  : " + score.ToString();
    }
}
