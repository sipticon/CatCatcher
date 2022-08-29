using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour{
    [SerializeField] private Text scoreText;
    [NonSerialized] public static int score;

    private void Update(){
        PlayerPrefs.SetInt("Score",score);
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
}