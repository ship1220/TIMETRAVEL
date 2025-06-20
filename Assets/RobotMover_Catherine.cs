using UnityEngine;

public class RobotMover_Catherine : MonoBehaviour
{
    public float moveDistance = 99.34f;
    public float moveSpeed = 3f;
    public float rotationSpeed = 90f; // degrees per second

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private bool goingForward = true;
    private bool rotating = false;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * moveDistance;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 180, 0) * startRotation;
    }

    void Update()
    {
        if (!rotating)
        {
            MoveRobot();
        }
        else
        {
            RotateRobot();
        }
    }

    void MoveRobot()
    {
        Vector3 target = goingForward ? targetPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            rotating = true;
        }
    }

    void RotateRobot()
    {
        Quaternion target = goingForward ? targetRotation : startRotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, target) < 0.5f)
        {
            rotating = false;
            goingForward = !goingForward;
        }
    }
}
