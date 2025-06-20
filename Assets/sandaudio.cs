using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRBaseInteractable))]
public class PlaySoundOnSandglassGrab : MonoBehaviour
{
    public AudioSource grabAudioSource;      // Assign in Inspector
    public AudioClip grabClip;               // Optional override

    private XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();

        if (grabAudioSource == null)
            grabAudioSource = GetComponent<AudioSource>();

        interactable.selectEntered.AddListener(OnGrab);
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (grabAudioSource != null)
        {
            if (grabClip != null)
                grabAudioSource.clip = grabClip;

            grabAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource found for sandglass.");
        }
    }
}
