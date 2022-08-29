using UnityEngine;
using UnityEngine.UI;

public class BuySpeed : MonoBehaviour
{
    [SerializeField] private Text speedhCount,catCoinsCount;
    [SerializeField] private AudioClip successBuy, wrongBuy;
    private AudioSource btnAudio;

    private void Awake()
    { 
        btnAudio = gameObject.GetComponent<AudioSource>();
    }
    public void buyPlusOneSpeed(){
        if(PlayerPrefs.GetInt("Coins") < 100)
            btnAudio.clip = wrongBuy;
        else if (PlayerPrefs.GetFloat("Speed") < 30f && PlayerPrefs.GetInt("Coins") >= 100){
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-100);
            PlayerPrefs.SetFloat("Speed", PlayerPrefs.GetFloat("Speed") + 1f);
            speedhCount.text = "Speed: " + PlayerPrefs.GetFloat("Speed");
            catCoinsCount.text = "Your CatCoins: " + PlayerPrefs.GetInt("Coins");
            btnAudio.clip = successBuy;
         }
        else if (PlayerPrefs.GetFloat("Speed") >= 30f){
            GetComponentInChildren<Text>().text = "You can't buy it anymore";
        }
        if (PlayerPrefs.GetString("Sound") == "Play")
            btnAudio.Play();
    }
}