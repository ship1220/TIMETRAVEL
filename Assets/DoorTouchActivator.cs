using UnityEngine;

public class DoorTouchActivator : MonoBehaviour
{
    public GameObject keypadPanel; // Drag your Keypad Panel here in the Inspector

    void Start()
    {
        //keypadPanel.SetActive(false); // Hide it on start
    }

    private void OnMouseDown() // Works in non-VR setup when clicked
    {
        //keypadPanel.SetActive(true); // Show keypad when door is clicked
    }
}

