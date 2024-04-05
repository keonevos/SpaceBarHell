using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private int score = 0;
    private int hightscore = 0;

    public bool Level1 = false;
    public bool Level2 = false;
    //private int hightScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (Level1 == true)
        {
            hightscore = PlayerPrefs.GetInt("hightscore", 0);
        }
        if (Level2 == true)
        {
            hightscore = PlayerPrefs.GetInt("hightscore2", 0);
        }
        
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
            if (Level1 == true)
            {
                PlayerPrefs.SetInt("hightscore", score);
            }
            else { }

            if (Level2 == true)
            {
                PlayerPrefs.SetInt("hightscore2", score);
            }
            else { }
        }
    }
}
