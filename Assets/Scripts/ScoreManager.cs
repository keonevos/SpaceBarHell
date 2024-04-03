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
    private int hightscore = 0;
    //private int hightScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hightscore = PlayerPrefs.GetInt("hightscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = "HIGHSCORE  : " + hightscore.ToString();
    }

    // Update is called once per frame
    public void AddScore(int inputScore)
    {
        score += inputScore;
        scoreText.text = score.ToString();
        if (hightscore < score)
        {
            PlayerPrefs.SetInt("hightscore", score);
        }
    }
}
