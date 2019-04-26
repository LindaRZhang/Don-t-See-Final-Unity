
using UnityEngine;

public class PlayerCollision1 : MonoBehaviour
{
    public PlayerMovement movement;     // A reference to our PlayerMovement script
    public AudioSource walls;
    void Start()
    {
        walls = GetComponent<AudioSource>();
        Debug.Log("Started");  
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;   // Disable the players movement.
            FindObjectOfType<GameManager>().EndGame();
        }
        if (collision.collider.name == "Barrier")
        {
            walls.Play();
            Debug.Log("Left");

        }
        if (collision.collider.name == "Barrier1")
        {
            walls.Play();
            Debug.Log("Right");

        }
    }
}
