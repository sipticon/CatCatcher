using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour{
    [SerializeField] private Text catCoinsCount, speedCount, healthCount;

    private void Start(){
        catCoinsCount.text = "Your CatCoins: " + PlayerPrefs.GetInt("Coins");
        speedCount.text = "Speed: " + PlayerPrefs.GetFloat("Speed");
        healthCount.text = "Health: " + Attempts.health;
    }
}