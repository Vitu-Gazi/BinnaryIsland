using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : Singleton<Score>
{
    [SerializeField] private TMP_Text scoreText;

    private int currentScore;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddScore (int plusScore)
    {
        currentScore += plusScore;
        scoreText.text = currentScore.ToString();
    }
}
