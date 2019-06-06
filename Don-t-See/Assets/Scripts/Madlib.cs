using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/* Linda Rong Zhang
*  This file executes the madlib game
*/
public class Madlib : MonoBehaviour
{
    public string story = "Yesterday, [person] " +
        "and I went to the park. On our way to the [adjective] park" +
        ", we saw a [adjective] [noun] on a bike. We also saw big [adjective] balloons " +
        "tied to a [noun]. Once we got to the [adjective] park. It started to " +
        "[verb] and [verb]. [person] and I [verb] all the way home. Tomorrow " +
        "we will try to go to the [adjective] park again and hope it doesn't [verb]. ";
    public Text word;
    public InputField input;
    List<string> s = new List<string>();//story list
    List<string> w = new List<string>();//noun, verb list
    List<string> inputed = new List<string>();//inputed words
    public string Finish1;
    public string Finish = "";
    public int count = 0;
    private int currentWordIndex = 0;
    private bool state = false;
    public bool z = false;
    public AudioSource Congrats;
    public AudioClip Song;
    public AudioClip verb;
    public AudioClip noun;
    public AudioClip Adj;
    public AudioClip personName;
    public bool entera;
    public bool click = true;
    public MainMenu M;
    List<AudioClip> clip = new List<AudioClip>();
    public AudioClip menu;
    //got every audio clip from https://www.text2speech.org/ except the bump sound that I made
    public void soundForWhatToEnter()
    {
        clip.Add(personName);
        clip.Add(Adj);
        clip.Add(Adj);
        clip.Add(noun);
        clip.Add(Adj);
        clip.Add(noun);
        clip.Add(Adj);
        clip.Add(verb);
        clip.Add(verb);
        clip.Add(personName);
        clip.Add(verb);
        clip.Add(Adj);
        clip.Add(verb);
    }
    public void enter()
    {
        z = true;
        if (z == true && input.text != "")
        {
            entera = true;
        }
    }
    public void Clear()
    {
        if ((0 < input.text.Count()))
        {
            input.text = "";
            input.ActivateInputField(); //let the blinker goes 
        }
    }

    public void askToEnter()
    {
        input.text = "";
        Clear();
        input.placeholder.GetComponent<Text>().text = "Enter a " + w[currentWordIndex]; //change placeholder
        if (w[currentWordIndex] == "noun")
        {
            Congrats.clip = noun;
        }
        if (w[currentWordIndex] == "person")
        {
           Congrats.clip = personName;
        }

        if (w[currentWordIndex] == "verb")
        {
            Congrats.clip = verb;
        }

        if (w[currentWordIndex] == "adjective")
        {
            Congrats.clip = Adj;
        }
        Congrats.Play();
    }

    public void makeSelected()
    {
        input.ActivateInputField();
    }
    public void Start()
    {
        soundForWhatToEnter();
        Invoke("makeSelected", 0.1f);
        if (Input.GetKeyDown("return"))
        {
            Start2();
        }
    }
    public void Start2()
    {
        
        if (input.text.ToLower() == "start") // if the input is equal to start then do the following
        {
            SSStart();
            askToEnter();
            state = true;
                z = true;
        }
        else if (input.text.ToLower() != "start" && state == false)
        {
            Clear();
        }
    }
    
    public void Update()
    {
        if (input.text.ToLower().Contains("clear") || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Clear();
        }
        if (Input.GetKeyDown("space"))
        {
            //Congrats.clip = help;
            //Congrats.Play();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Congrats.Stop();
        }
        if (Input.GetMouseButtonDown(0))
        {
            z = true;
            if (click == true)//making input being able to type or not
            {
                input.interactable = true;
                Debug.Log("Active Input");
                click = false;
            }
            else
            {
                input.interactable = false;
                input.DeactivateInputField();
                click = true;
            }
        }
        if (Input.GetKeyDown("return") && z == true && input.text != "" || entera == true)//when in the input field, the user typed enter
        {
            Clear();
            word.text = "Welcome to MadLib";
            if (state == true)
            {
                if (currentWordIndex <= w.Count())
                {
                    inputed.Add(input.text);
                    currentWordIndex++;
                    askToEnter();
                    entera = false;
                }
                else
                {
                    PrintStory();
                    z = false;
                    input.DeactivateInputField();
                }
            }
        }
        else
        {
            Start();
        }
    }

    public void SSStart()
    {
        foreach (string i in story.Split())//loop original story
        {
            s.Add(i);
            if (i.StartsWith("["))
            {
                w.Add(i);
            }
        }
    }

    public void PrintStory()
    {
        foreach (string h in s)//loop to put the story together
        {
            if (h.StartsWith("["))
            {
                Finish1 = inputed[count];
                count++;
            }
            else
            {
                Finish1 = h;
            }
            Finish += Finish1 + " ";
        }
        word.text = Finish;
        input.text = "Congratulations!";
        input.DeactivateInputField();
        Congrats.clip = Song;
        Congrats.Play();
       if (M.menu)
        {
            Congrats.clip = menu;
            Congrats.Play();
            if (input.text == "P" || input.text == "p")
            {
                Debug.Log("LoadMadLIB");
                SceneManager.GetActiveScene();
            }
            else if (input.text == "Q" || input.text == "q")
            {
                Debug.Log("LoadMenu");
                SceneManager.LoadScene("Menu_bar");
            }
        }
        else
        {
            Debug.Log("LoadSimpleMaze");
            SceneManager.LoadScene("Simple-maze");
        }
    }
}
