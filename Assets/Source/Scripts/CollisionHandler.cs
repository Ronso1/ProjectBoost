using UnityEngine;

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
                Debug.Log("You blew up! Game over");
                break;
        }
    }
}
