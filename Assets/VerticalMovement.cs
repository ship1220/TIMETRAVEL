using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Adjust in Inspector

    void Update()
    {
        float verticalY = 0f;

        if (Input.GetKey(KeyCode.R))  // Move up
            verticalY = 1f;
        else if (Input.GetKey(KeyCode.F))  // Move down
            verticalY = -1f;

        transform.Translate(Vector3.up * verticalY * speed * Time.deltaTime);
    }
}
