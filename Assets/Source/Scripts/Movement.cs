using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusting");
        }       
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate right");
        }
    }
}
