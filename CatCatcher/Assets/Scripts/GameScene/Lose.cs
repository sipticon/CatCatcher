using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour{
    [SerializeField] private GameObject gamePanel, losePanel, loseSound;
    [SerializeField] private Text score, bestScore;
    private static int best;
    private bool isLost;
    void Update(){
        if (PlayerPrefs.GetInt("Health") <= 0 && !isLost){
            PlayerPrefs.SetString("IsLost","True");
            if(PlayerPrefs.GetString("Sound") == "Play")
                Instantiate(loseSound);
            gamePanel.SetActive(false);
            losePanel.SetActive(true);
            score.text = "Score: " + PlayerPrefs.GetInt("Score");
            if (best < PlayerPrefs.GetInt("Score")){
                best = PlayerPrefs.GetInt("Score");
                bestScore.text = "Best score: " + PlayerPrefs.GetInt("Score");
            }
            else
                bestScore.text = "Best score: " + best;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")+PlayerPrefs.GetInt("Score"));
            isLost = true;
        }
    }
}