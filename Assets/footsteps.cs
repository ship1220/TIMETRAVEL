using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class XRFootsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float stepDelay = 0.5f;
    public float movementThreshold = 0.01f;

    private AudioSource audioSource;
    private float stepTimer;
    private Vector3 lastPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepTimer = 0f;
        lastPosition = transform.position;
    }

    void Update()
    {
        float movedDistance = Vector3.Distance(transform.position, lastPosition);
        Debug.Log("Moved Distance: " + movedDistance);

        if (movedDistance > movementThreshold)
        {
            stepTimer -= Time.deltaTime;
            Debug.Log("Moving. Step Timer: " + stepTimer);

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepDelay;
            }
        }
        else
        {
            Debug.Log("Not moving.");
            stepTimer = 0f;
        }

        lastPosition = transform.position;
    }


    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            audioSource.PlayOneShot(footstepClips[index]);
        }
    }
}
