using UnityEngine;
public class Cat : MonoBehaviour{
    [SerializeField] private GameObject catchCatSound, fallCatSound;
    private bool isOnGround, playerTouch, isMove;
    private void Update(){
        if (isMove)
            GetComponent<Rigidbody2D>().MovePosition(transform.position + 
                                                     ((transform.position.x > 0 ? transform.right : -transform.right) * 10f * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (!playerTouch && collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            isMove = true;
            if (PlayerPrefs.GetString("Sound") == "Play")
                Instantiate(fallCatSound);
            PlayerPrefs.SetInt("Health",PlayerPrefs.GetInt("Health")-1);
            gameObject.layer = LayerMask.NameToLayer("FalledCat");
        }
        if (!isOnGround && collision.gameObject.CompareTag("Player")){
            playerTouch = true;
            ScoreController.score++;
            if(PlayerPrefs.GetString("Sound") == "Play")
                Instantiate(catchCatSound);
            Destroy(gameObject);
        }
        else if(isOnGround && collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}