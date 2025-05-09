using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Assign in the Inspector
    public float speed = 5f;
    private bool following = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            following = true;
        }
    }

    void Update()
    {
        if (following && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
