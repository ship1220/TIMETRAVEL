using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public float sidewaysForce=1500f;
    public float forwardForce = 3000f;
    void Start()
    {
        Debug.Log("Hello World");
        
        //rb.AddForce(0, 0, 200);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 50 * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0,-forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

    }
}
