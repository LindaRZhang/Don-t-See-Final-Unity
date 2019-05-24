using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 [System.Serializable]
public class Questions : MonoBehaviour
<<<<<<< HEAD
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

    
=======
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


>>>>>>> cf28fa330bfa27f40d5819e75a97315919d76d72
    void Start()
    {


        count = 0;
        question = GetComponent<Text>();
<<<<<<< HEAD
        question.text = questions[count];
        RedButton.onClick.AddListener(OnClick);
        YellowButton.onClick.AddListener(OnClick);
=======
        question.text = questions[count].listquestion;
        redButton.onClick.AddListener(OnClick);
        yellowButton.onClick.AddListener(OnClick);
>>>>>>> cf28fa330bfa27f40d5819e75a97315919d76d72


    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
<<<<<<< HEAD
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
=======
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

>>>>>>> cf28fa330bfa27f40d5819e75a97315919d76d72
}
