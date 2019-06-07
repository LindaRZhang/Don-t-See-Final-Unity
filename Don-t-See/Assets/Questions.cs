using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 [System.Serializable]
public class Questions : MonoBehaviour
{
    public AudioSource questionaudio;
    public AudioClip[] AudioClips;
    public  AudioSource music1;
    public  AudioSource music2;

    public class Question
    {
        public string listquestion;
        public bool answer;
        public AudioSource questionaudio;
        public Question(string name, bool theAnswer)
        {
            listquestion = name;
            answer = theAnswer;

        }

    }
    public Button redButton, yellowButton;
    int count = 0;
    public static List<Question> questions = new List<Question> {
        new Question("Welcome!",true),
        new Question("Question 1: The American Civil War ended in 1776?", false),
        new Question("Question 2: A right triangle can never be equilateral?",true),
        new Question("Question 3: The Bill of Rights contains 10 amendments to the Constitution?",true),
        new Question("Question 4: Snow White’s seven dwarfs all worked as lumberjacks?",false),
        new Question("Question 5: There are seven red stripes in the United States flag?",true),
        new Question("Question 6: Are there 50 states in United States?",true),
        new Question("Nice gob!",true)



    };
    Text question;

    // Start is called before the first frame update


    void Start()
    {


        count = 0;
        question = GetComponent<Text>();
        questionaudio = GetComponent<AudioSource>();
        question.text = questions[count].listquestion;
        redButton.onClick.AddListener(OnClick);
        yellowButton.onClick.AddListener(OnClick);


    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene("Menu_bar");
        }
      
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            OnClick();


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

           
            OnClick();

        }
    }
    void OnClick()
    {
        question = GetComponent<Text>();
        questionaudio.clip = AudioClips[count];
        question.text = questions[count+1].listquestion;
        questionaudio.PlayOneShot(questionaudio.clip);

        if (count == 0)
        {
            Debug.Log("play");
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                music1.Stop();
                music2.Stop();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                music2.Stop();
                music1.Stop();
            }
        }
        else if (count != 0 && count <= 6)
        {
            if (questions[count].answer == false)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                    music1.Stop();
                    music2.Play();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {



                    music2.Stop();
                    music1.Play();
                }
            }
            else if (questions[count].answer == true)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {



                    music2.Stop();
                    music1.Play();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    music1.Stop();
                    music2.Play();
                }

            }
            if (count == 6)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {


                    Debug.Log("False");
                    SceneManager.LoadScene("Second Maze");


                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("True");
                    Start();

                }
            }

        }

        Debug.Log(count);
        count++;
    }

}
