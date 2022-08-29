using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void startGame(){
        StartCoroutine(openGame());
        PlayerPrefs.SetString("IsLost","False");
        ScoreController.score = 0;
        Time.timeScale = 1f;
    }
    IEnumerator openGame()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Game");
    }
}