using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBodyOfRocket;
    [SerializeField] private float _mainTrustPower = 1000f;
    [SerializeField] private float _rotationTrustPower = 100f;

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBodyOfRocket.AddRelativeForce(Vector3.up * _mainTrustPower * Time.deltaTime);
        }       
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotationTrustPower);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotationTrustPower);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidBodyOfRocket.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidBodyOfRocket.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}
