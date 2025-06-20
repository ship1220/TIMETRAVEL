using UnityEngine;
using Unity.XR.CoreUtils;

public class XRRigKeyboardMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 60f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotateY = 0;

        if (Input.GetKey(KeyCode.Q)) rotateY = -rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) rotateY = rotateSpeed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);
        transform.Rotate(0, rotateY, 0);
    }
}

