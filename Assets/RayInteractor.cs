using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VRRayClicker : MonoBehaviour
{
    public Transform controllerRayOrigin; // Assign the controller's transform
    public float rayDistance = 10f;
    public LayerMask uiLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Replace with XR input
        {
            Ray ray = new Ray(controllerRayOrigin.position, controllerRayOrigin.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, uiLayer))
            {
                Button btn = hit.collider.GetComponent<Button>();
                if (btn != null)
                {
                    Debug.Log("Button hit and clicked via ray!");
                    btn.onClick.Invoke();
                }
            }
        }
    }
}
