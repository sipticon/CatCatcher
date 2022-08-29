using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void restartGame(){
        if (PlayerPrefs.GetString("IsLost") == "True"){
            SceneManager.LoadScene("Game");
            PlayerPrefs.SetString("IsLost","False");
            ScoreController.score = 0;
        }
    }
}