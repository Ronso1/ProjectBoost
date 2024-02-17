using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _crashClip;
    [SerializeField] private AudioClip _winClip;
    [Space]
    [SerializeField] private float _levelDelayTime = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You touch friendly object");
                break;
            case "Fuel":
                Debug.Log("You take a fuel!");
                break;
            case "Finish":
                PlayAudioClip(_winClip);
                StartLoadingNextScene();
                break;
            default:
                PlayAudioClip(_crashClip);
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
        _playerAudioSource.PlayOneShot(clip);
    }
}
