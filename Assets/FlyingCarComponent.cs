using UnityEngine;

public class FlyingCarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float stopX = 92.6f;

    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

            // Check if the car has reached or passed stopX
            if (transform.position.x >= stopX)
            {
                isMoving = false; // stop moving
            }
        }
    }
}
