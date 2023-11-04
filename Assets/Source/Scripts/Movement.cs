using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBodyOfRocket;

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBodyOfRocket.AddRelativeForce(Vector3.up);
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
