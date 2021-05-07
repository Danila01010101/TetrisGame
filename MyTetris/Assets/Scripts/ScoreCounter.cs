using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private int _score;
    
    public void UpdateScore(int addToScore)
    {
        _score += addToScore;
        _scoreText.text = "Score : " + _score;
    }
}
