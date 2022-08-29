using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    private bool isPlay = true;
    private AudioSource musicAudioSource;
    private Text onOffText;

    private void Start()
    {
        onOffText = GetComponentInChildren<Text>();
        musicAudioSource = GameObject.Find("BackGroundMusic(Clone)").GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("Sound") == "Pause")
        {
            isPlay = false;
            onOffText.text = "Sound On";
        }
    }

    public void soundOnOff()
    {
        if (isPlay)
        {
            PlayerPrefs.SetString("Sound", "Pause");
            musicAudioSource.Pause();
            onOffText.text = "Sound On";
        }
        else
        {
            PlayerPrefs.SetString("Sound", "Play");
            if(PlayerPrefs.GetString("Sound") == "Play")
            musicAudioSource.Play();
            onOffText.text = "Sound Off";
        }
        isPlay = !isPlay;
    }
}