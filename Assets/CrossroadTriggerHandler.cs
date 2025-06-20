using UnityEngine;

public class CrossroadTriggerHandler : MonoBehaviour
{
    public AudioSource robotAudioSource;
    public AudioClip crossroadClip;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("🚨 Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            if (robotAudioSource != null && crossroadClip != null)
            {
                robotAudioSource.clip = crossroadClip;
                robotAudioSource.Play();
                Debug.Log("✅ Robot is speaking now.");
            }
            else
            {
                Debug.LogWarning("⚠️ Missing audio source or clip!");
            }
        }
    }
}
