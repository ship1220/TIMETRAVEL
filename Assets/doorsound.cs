using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRBaseInteractable))]
public class PlayDoorAudioOnGrab : MonoBehaviour
{
    public AudioSource doorAudioSource;  // Assign in Inspector
    public AudioClip doorSound;          // Optional: can assign a custom sound

    private XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();

        if (doorAudioSource == null)
            doorAudioSource = GetComponent<AudioSource>();

        interactable.selectEntered.AddListener(OnDoorGrabbed);
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnDoorGrabbed);
    }

    private void OnDoorGrabbed(SelectEnterEventArgs args)
    {
        if (doorAudioSource != null)
        {
            if (doorSound != null)
                doorAudioSource.clip = doorSound;

            doorAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned on the door.");
        }
    }
}
