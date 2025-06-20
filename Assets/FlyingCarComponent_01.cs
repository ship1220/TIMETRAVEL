using UnityEngine;

public class FlyingCarMovement_01 : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
}
