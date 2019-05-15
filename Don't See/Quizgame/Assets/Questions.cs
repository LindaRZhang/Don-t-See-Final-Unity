using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 [System.Serializable]
public class Questions : MonoBehaviour
{

    public Button RedButton, YellowButton;
    int count = 0;
    List<string> questions = new List<string> {
    "Question 1: 1 + 1 = 2?",
    "Question 2: 1 + 1 = 3?",
    "Question 3: 1 + 2 = 4?",
    "Question 4: 1 + 5 = 6?"
    };

    List<bool> answers = new List<bool>
    {
        true,
        false,
        false,
        true
    };
   

    Text question;
    // Start is called before the first frame update

    
    void Start()
    {


        count = 0;
        question = GetComponent<Text>();
        question.text = questions[count];
        RedButton.onClick.AddListener(OnClick);
        YellowButton.onClick.AddListener(OnClick);


    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            YellowButton.onClick.AddListener(OnClick);
            OnClick();

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RedButton.onClick.AddListener(OnClick);
            OnClick();
        }

    }
    void OnClick()
    {
        count++;
        if (count == questions.Count)
        {
            count = 0;

        }
        question = GetComponent<Text>();
        question.text = questions[count];
        







    }
    void TOF()
    {
       


    }
}
