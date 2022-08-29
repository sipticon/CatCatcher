using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectstoSpawn;
    [SerializeField] private float timeToSpawnFrom = 2f, timeToSpawnTo = 4f;
    private Coroutine objectSpawnCoroutine;
    private float timeToSpawn;
    private void Start(){
        objectSpawnCoroutine = StartCoroutine(spawnObject());
    }

    private void Update(){
        if(PlayerPrefs.GetString("IsLost") == "True")
            StopCoroutine(objectSpawnCoroutine);
    }

    IEnumerator spawnObject(){
        while (true){
            float location = Random.Range(-2f, 2f);
            Vector3 spawnPos = new Vector3(transform.position.x + location, transform.position.y);
            GameObject newObj = Instantiate(objectstoSpawn[Random.Range(0, objectstoSpawn.Length)], spawnPos, Quaternion.identity);
            if (PlayerPrefs.GetString("Sound") == "Play")
                newObj.GetComponent<AudioSource>().Play();
            if (location > 0)
                newObj.GetComponent<SpriteRenderer>().flipX = true;
            else if (location < 0)
                newObj.GetComponent<SpriteRenderer>().flipX = false;
            timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
            if (PlayerPrefs.GetInt("Score") !=0 && PlayerPrefs.GetInt("Score") % 5 == 0){
                if(timeToSpawnFrom < 0.5f)
                    timeToSpawnFrom = 0.4f;
                else
                    timeToSpawnFrom -= 0.3f;
                if(timeToSpawnTo < 1.1f)
                    timeToSpawnTo = 1f;
                else
                    timeToSpawnTo -= 0.3f;
            }
        }
    }
}