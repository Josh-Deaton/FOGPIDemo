using UnityEngine;
using UnityEngine.SceneManagement; // Optional if you're loading a new scene

public class EndLevelDoor : MonoBehaviour
{
    private bool playerInTrigger = false;
    private bool followerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }

        if (other.CompareTag("Follower"))
        {
            followerInTrigger = true;
        }

        CheckLevelEnd();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }

        if (other.CompareTag("Follower"))
        {
            followerInTrigger = false;
        }
    }

    private void CheckLevelEnd()
    {
        if (playerInTrigger && followerInTrigger)
        {
            Debug.Log("Level Complete!");
        }
    }
}
