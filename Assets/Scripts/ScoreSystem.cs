using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 10;

    public const string HighScoreKey = "HighScore";
    private float score;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        score += scoreMultiplier * Time.deltaTime;
        
        scoreText.text =  Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy() //PlayerPrefs can store values between game sessions
    {
        int prevHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > prevHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}
