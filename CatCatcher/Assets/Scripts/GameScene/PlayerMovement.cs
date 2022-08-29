using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _playerRb2D;
    private Vector3 newPos;
    private Animator animator;
    private static bool isFirstGame = true;
    private void Start(){
        if (isFirstGame){
            PlayerPrefs.SetFloat("Speed", 15f);
            isFirstGame = false;
        }
        speed = PlayerPrefs.GetFloat("Speed");
        PlayerPrefs.SetString("IsLost", "False");
        _playerRb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update(){
        if (Input.GetMouseButton(0) && PlayerPrefs.GetString("IsLost") == "False")
            followTouch();
    }

    private void followTouch(){
#if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#else
        if (Input.touchCount == 0)
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif
        newPos = ray.origin + ray.direction/2f;
        Vector2 dir = new Vector2(newPos.x - transform.position.x, 0);
        GetComponent<Animator>().SetFloat("Direction", dir.x);
        _playerRb2D.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
        animator.SetTrigger("Move");
    }
}