using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _crashClip;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private ParticleSystem _crashParticle;
    [SerializeField] private ParticleSystem _winParticle;
    [Space]
    [SerializeField] private float _levelDelayTime = 2f;

    private bool _isTransitioning = false;
    private bool _collisionDisabled;

    private void Update()
    {
        ChangeStateOfCollision();
    }

    private void ChangeStateOfCollision()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _collisionDisabled = !_collisionDisabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTransitioning || _collisionDisabled)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                PlayAudioClip(_winClip);
                _winParticle.Play();
                StartLoadingNextScene();
                break;
            default:
                PlayAudioClip(_crashClip);
                _crashParticle.Play();
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", 1f);
    }

    private void StartLoadingNextScene()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadLevel", _levelDelayTime);
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    private void PlayAudioClip(AudioClip clip)
    {
        _playerAudioSource.Stop();
        _playerAudioSource.PlayOneShot(clip);
        _isTransitioning = true;
    }
}