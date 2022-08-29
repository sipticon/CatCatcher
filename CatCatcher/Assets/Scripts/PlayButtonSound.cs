using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    public void playButtonSound(){
        if (PlayerPrefs.GetString("Sound") == "Play")
            GetComponent<AudioSource>().Play();
    }
}