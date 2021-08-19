using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class ButtonActivation : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private CircleCollider2D buttonCollider;    
    [SerializeField] private bool buttonA, buttonB;
    public static bool isButtonAPressed, isButtonBPressed;

    private void Awake()
    {        
        buttonCollider = button.GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        isButtonAPressed = false;
        isButtonBPressed = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (buttonA)
        {
            isButtonAPressed = UnlockButton();
        }
        else if (buttonB)
        {
            isButtonBPressed = UnlockButton();
        }
    }

    private bool UnlockButton()
    {
        AudioManager.instance.PlaySound(AudioManager.ACTIVATION_SOUND);
        buttonCollider.enabled = false;
        return true;
    }
}
