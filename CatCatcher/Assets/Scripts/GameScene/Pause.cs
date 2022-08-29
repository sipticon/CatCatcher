using UnityEngine;

public class Pause : MonoBehaviour{
    [SerializeField] private GameObject pausePanel, gamePanel;
    public void setPause(){
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
    }
}