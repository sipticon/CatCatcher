using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]private GameObject backgroundMusic;
    private GameObject[] firstObject;

    void Awake() {
        firstObject = GameObject.FindGameObjectsWithTag("Sound");
        if (firstObject.Length == 0)
        {
            backgroundMusic = Instantiate(backgroundMusic);
            DontDestroyOnLoad(backgroundMusic.gameObject);
            if(PlayerPrefs.GetString("Sound") == "Pause")
                backgroundMusic.GetComponent<AudioSource>().Pause();
        }
    }
}