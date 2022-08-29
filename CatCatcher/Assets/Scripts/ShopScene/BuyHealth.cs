using UnityEngine;
using UnityEngine.UI;

public class BuyHealth : MonoBehaviour{
    [SerializeField] private Text healthCount, catCoinsCount;
    [SerializeField] private AudioClip successBuy, wrongBuy;
    private AudioSource btnAudio;

    private void Awake()
    { 
        btnAudio = gameObject.GetComponent<AudioSource>();
    }

    public void buyPlusOneHealth()
    {
        if (PlayerPrefs.GetInt("Coins") < 1000)
            btnAudio.clip = wrongBuy;
        else if (Attempts.health < 5 && PlayerPrefs.GetInt("Coins") >= 1000){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-1000);
            Attempts.health++;
            healthCount.text = "Health: " + Attempts.health;
            catCoinsCount.text = "Your CatCoins: " + PlayerPrefs.GetInt("Coins");
            btnAudio.clip = successBuy;
        }
        else if (Attempts.health >= 5)
            GetComponentInChildren<Text>().text = "You can't buy it anymore";
        if (PlayerPrefs.GetString("Sound") == "Play")
            btnAudio.Play();
    }
}