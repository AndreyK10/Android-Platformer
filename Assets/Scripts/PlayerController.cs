using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool isDead;
    public GameObject cinemachineCamera;

    private void Start()
    {
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            cinemachineCamera.SetActive(false);
            isDead = true;
        }
    }
}
