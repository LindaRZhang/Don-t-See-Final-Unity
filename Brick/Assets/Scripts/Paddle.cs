using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	private Vector3 playerPos = new Vector3(0,-9.5f,0);
    
    public GameObject ball;
    public AudioSource left;
   // public AudioClip left1;
    public AudioSource right;
    //public AudioClip right1;
    int ol = 0;


    // Update is called once per frame
    void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0);
		transform.position = playerPos;
       // left.clip = left1;
       // right.clip = right1;
        float BallPos = ball.transform.position.x;
        float PadPos = transform.position.x;
        
        if (BallPos < PadPos)
        { 
            if(ol==0)
                { 
                right.Stop();
                left.Play();
            ol = 1;
            }
            Debug.Log("Left");

        }
        if (BallPos > PadPos)
        {
        if(ol == 1)
        {
        left.Stop();
        right.Play();
                ol = 0;
        }
        Debug.Log("Right");
        }
        
    }
}
