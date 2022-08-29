using UnityEngine;
using UnityEngine.UI;

public class SoundButtonText : MonoBehaviour{
    [SerializeField] private Text soundButtonsText;
    private void Start(){
        if (PlayerPrefs.GetString("Sound") != "Play")
            soundButtonsText.text = "Sound On";
        else
            soundButtonsText.text = "Sound Off";
    }
}
