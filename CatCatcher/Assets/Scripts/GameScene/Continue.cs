using UnityEngine;

public class Continue : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel, gamePanel;
    public void continueGame(){
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}