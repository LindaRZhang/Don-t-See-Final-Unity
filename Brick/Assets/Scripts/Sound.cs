using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float BallPos = ball.transform.position.x;
        float paddlePos = paddle.transform.position.x;
        if (BallPos<paddlePos)
        {
            Debug.Log("LOL left");

        }
        if (BallPos > paddlePos)
        {
            Debug.Log("LOL Right");

        }
    }
}
