using UnityEngine;

public class DeleteSound : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}