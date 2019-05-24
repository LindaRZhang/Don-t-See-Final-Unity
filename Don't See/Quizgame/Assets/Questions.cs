using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 [System.Serializable]
public class Questions : MonoBehaviour
{
    public  AudioSource music1;
    public  AudioSource music2;
    public class Question
    {
        public string listquestion;
        public bool answer;
        public Question(string name, bool theAnswer)
        {
            listquestion = name;
            answer = theAnswer;
        }

    }
    public Button redButton, yellowButton;
    int count = 0;
    public static List<Question> questions = new List<Question> {
        new Question("Question 1: 1 + 1 = 2?", true),
        new Question("Question 2: 1 + 1 = 3?",false),
        new Question("Question 3: 1 + 2 = 4?",false),
        new Question("Question 4: 1 + 5 = 6?",true),
        new Question("Nice gob!",true)
    };
    Text question;

    // Start is called before the first frame update


    void Start()
    {


        count = 0;
        question = GetComponent<Text>();
        question.text = questions[count].listquestion;
        redButton.onClick.AddListener(OnClick);
        yellowButton.onClick.AddListener(OnClick);


    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            yellowButton.onClick.AddListener(OnClick);
            OnClick();


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            redButton.onClick.AddListener(OnClick);
            OnClick();

        }
    }
    void OnClick()
    {
        question = GetComponent<Text>();
        question.text = questions[count+1].listquestion;
        if (questions[count].answer == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)){

                music1.Stop();
                music2.Play();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)){

                music2.Stop();
                music1.Play();
            }
        }

        else if (questions[count].answer == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)){
               
                music2.Stop();
                music1.Play();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)){

                music1.Stop();
                music2.Play();
            }

        }

        Debug.Log(count);
        count++;
    }

}
