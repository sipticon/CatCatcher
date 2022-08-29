using UnityEngine;

public class CatchTrash : MonoBehaviour{
    [SerializeField] private GameObject catchTrashSound;
    private bool isOnGround, playerTouch;
    private void OnCollisionEnter2D(Collision2D collision){
        if (!playerTouch && collision.gameObject.CompareTag("Ground")){
            Destroy(gameObject,0.2f);
            gameObject.layer = LayerMask.NameToLayer("FalledCat");
        }
        if (collision.gameObject.CompareTag("Player")){
            playerTouch = true;
            if(PlayerPrefs.GetString("Sound") == "Play")
                Instantiate(catchTrashSound);
            Destroy(gameObject);
            PlayerPrefs.SetInt("Health",PlayerPrefs.GetInt("Health")-1);
        }
        else if(!isOnGround && collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
        else if(!isOnGround && collision.gameObject.CompareTag("Cat"))
            Destroy(gameObject);
    }
}