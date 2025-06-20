using UnityEngine;
using UnityEngine.UI;

public class DoorUnlocker : MonoBehaviour
{
    public string correctPin = "1234"; // You can change this PIN!
    public InputField pinInputField;   // Connect this in the Inspector
    public Animator doorAnimator;      // Connect your door's Animator here

    public void CheckPin()
    {
        if (pinInputField.text == correctPin)
        {
            Debug.Log("Correct PIN! Opening the door...");
            doorAnimator.SetTrigger("Open"); // This plays the animation
        }
        else
        {
            Debug.Log("Wrong PIN. Try again!");
        }
    }
}

