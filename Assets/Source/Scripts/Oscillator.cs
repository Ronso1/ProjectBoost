using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private const float Tau = Mathf.PI;

    [SerializeField] private Vector3 _movingVector;
    [SerializeField] private float _period = 2f;
    private float _movingFactor;

    private Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        if (_period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / _period;
        float rawSinWave = Mathf.Sin(cycles * Tau);

        _movingFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = _movingVector * _movingFactor;
        transform.position = offset;
    }
}
