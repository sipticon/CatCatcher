using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart, emptyHeart;
    public static int health = 3;
    private static int numOfHealth;
    private static bool isFirstGame;
    private void Start(){
        PlayerPrefs.SetInt("Health", health);
        numOfHealth = PlayerPrefs.GetInt("Health");
    }
    private void Update(){
        int nowHealth = PlayerPrefs.GetInt("Health");
        if (nowHealth > numOfHealth)
            nowHealth = numOfHealth;
        for (int i = 0; i < hearts.Length; i++){
            if (i < nowHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
            if (i < numOfHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}