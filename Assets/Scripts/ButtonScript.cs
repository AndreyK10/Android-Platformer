using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject button, finishLight;
    private CircleCollider2D buttonCollider;
    private SpriteRenderer buttonSR, lightSR;
    [SerializeField] private bool buttonA, buttonB;
    public static bool buttonAPressed, buttonBPressed;
    

    private void Awake()
    {
        buttonSR = button.GetComponent<SpriteRenderer>();
        lightSR = finishLight.GetComponent<SpriteRenderer>();
        buttonCollider = button.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (buttonA)
        {
            buttonAPressed = UnlockButton();
        }
        else if (buttonB)
        {
            buttonBPressed = UnlockButton();
        }
    }

    private bool UnlockButton()
    {
        buttonSR.color = Color.green;
        lightSR.color = Color.green;
        buttonCollider.enabled = false;
        return true;
    }
}
