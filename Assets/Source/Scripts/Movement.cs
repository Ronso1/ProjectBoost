using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBodyOfRocket;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _thrustEngineClip;
    [SerializeField] private ParticleSystem _mainEngineParticle;
    [SerializeField] private ParticleSystem _leftSideEngineParticle;
    [SerializeField] private ParticleSystem _rightSideEngineParticle;
    [SerializeField] private ParticleSystem _middleSideEngineParticle;
    [Space]
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
            StartThrusting();
        }
        else if (_audioSource.isPlaying)
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop();
        _mainEngineParticle.Stop();
    }

    private void StartThrusting()
    {
        _rigidBodyOfRocket.AddRelativeForce(Vector3.up * _mainTrustPower * Time.deltaTime);

        if (_audioSource.isPlaying is false)
        {
            _audioSource.PlayOneShot(_thrustEngineClip);
            _mainEngineParticle.Play();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotatingRight()
    {
        ApplyRotation(-_rotationTrustPower);
        StartParticlePlay(_rightSideEngineParticle);
        StartParticlePlay(_middleSideEngineParticle);
    }

    private void RotatingLeft()
    {
        ApplyRotation(_rotationTrustPower);
        StartParticlePlay(_leftSideEngineParticle);
        StartParticlePlay(_middleSideEngineParticle);
    }

    private void StopRotating()
    {
        _leftSideEngineParticle.Stop();
        _rightSideEngineParticle.Stop();
        _middleSideEngineParticle.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidBodyOfRocket.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidBodyOfRocket.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }

    private void StartParticlePlay(ParticleSystem particle)
    {
        if (particle.isPlaying is false)
        {
            particle.Play();
        }
    }
}
