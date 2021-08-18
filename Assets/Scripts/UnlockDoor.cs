using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private void Update()
    {
        if (ButtonScript.buttonAPressed && ButtonScript.buttonBPressed)
        {
            gameObject.SetActive(false);
        }
    }
}
