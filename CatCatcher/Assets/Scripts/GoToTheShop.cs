using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheShop : MonoBehaviour
{
    public void startShop(){
        StartCoroutine(openShop());
        Time.timeScale = 1f;
    }
    IEnumerator openShop()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Shop");
    }
}