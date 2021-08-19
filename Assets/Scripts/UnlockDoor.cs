using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private void Update()
    {
        if (ButtonActivation.isButtonAPressed && ButtonActivation.isButtonBPressed)
        {
            gameObject.SetActive(false);
        }
    }
}
