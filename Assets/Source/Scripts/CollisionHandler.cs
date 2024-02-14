using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                Debug.Log("You completed level!");
                break;
            default:
                ReloadScene();
                break;
        }
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
