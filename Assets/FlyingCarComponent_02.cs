using UnityEngine;

public class FlyingCarMovement_02 : MonoBehaviour
{
    public float speed = 5f;
    public float stopZ = 346.56f;

    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;

            // Check if the car has reached or passed stopZ
            if (transform.position.z >= stopZ)
            {
                isMoving = false; // stop moving
            }
        }
    }
}

