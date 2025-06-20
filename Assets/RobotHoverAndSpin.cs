using UnityEngine;

public class RobotHoverAndSpin : MonoBehaviour
{
    public float floatHeight = 2f;       // how high it goes up
    public float floatSpeed = 2f;        // how fast it goes up/down
    public float rotationSpeed = 360f;   // degrees per second

    private Vector3 startPos;
    private bool goingUp = true;
    private float currentRotation = 0f;
    private bool rotating = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (goingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.up * floatHeight, floatSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos + Vector3.up * floatHeight) < 0.01f)
            {
                goingUp = false;
                rotating = true;
                currentRotation = 0f;
            }
        }
        else if (rotating)
        {
            float rotateThisFrame = rotationSpeed * Time.deltaTime;
            if (currentRotation + rotateThisFrame >= 360f)
            {
                rotateThisFrame = 360f - currentRotation;
                rotating = false;
            }

            transform.Rotate(Vector3.up, rotateThisFrame);
            currentRotation += rotateThisFrame;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, floatSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos) < 0.01f)
            {
                goingUp = true;
            }
        }
    }
}

