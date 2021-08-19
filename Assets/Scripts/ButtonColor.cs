using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonColor : MonoBehaviour
{
    [SerializeField] private GameObject button, finishLight;
    private SpriteRenderer buttonSR, lightSR;
    [SerializeField] private bool buttonA, buttonB;
    public Light2D doorLight;

    private void Awake()
    {
        buttonSR = button.GetComponent<SpriteRenderer>();
        lightSR = finishLight.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckButton(buttonA, ButtonActivation.isButtonAPressed);
        CheckButton(buttonB, ButtonActivation.isButtonBPressed);
    }

    private void CheckButton(bool buttonName, bool state)
    {
        if (buttonName)
        {
            if (state)
            {
                buttonSR.color = Color.green;
                lightSR.color = Color.green;
                doorLight.color = Color.green;
            }
            else
            {
                buttonSR.color = Color.red;
                lightSR.color = Color.red;
                doorLight.color = Color.red;
            }
        }
    }
}
