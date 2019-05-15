using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RedButton : MonoBehaviour
{

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;


        }
    }
}
