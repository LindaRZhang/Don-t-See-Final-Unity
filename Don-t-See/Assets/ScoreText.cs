using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Button redButton;
    public static Text scores;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scores = GetComponent<Text>();
        scores.text = "Score: " + score;
        redButton.onClick.AddListener(Point);
    }

    // Update is called once per frame

    void Point()
    {
        score++;
        scores.text = "Score: " + score;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            score++;
            scores.text = "Score: " + score;

        }
    }
}