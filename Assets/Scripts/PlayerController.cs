using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public static bool isDead, isFinished, isActivated, isDeactivated;
    [SerializeField] private GameObject cinemachineCamera;
    private PlayerMovement playerM;


    private void Awake()
    {
        playerM = GetComponent<PlayerMovement>();
        //playerM.enabled = false;
    }
    private void Start()
    {
        isDead = false;
        isFinished = false;
        isActivated = false;
        isDeactivated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            cinemachineCamera.SetActive(false);
            isDead = true;
        }
        if (collision.CompareTag("Activator"))
        {
            isActivated = true;
            collision.gameObject.SetActive(false);
            playerM.enabled = true;
        }
        if (collision.CompareTag("FinalCutScene"))
        {
            isDeactivated = true;
            collision.gameObject.SetActive(false);
            cinemachineCamera.SetActive(false);
            playerM.enabled = false;
        }
        if (collision.CompareTag("Finish"))
        {
            isFinished = true;
        }
    }
}
