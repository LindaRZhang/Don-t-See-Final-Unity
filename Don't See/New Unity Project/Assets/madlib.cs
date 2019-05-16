using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class madlib : MonoBehaviour
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

    public void askToEnter()
    {
        input.text = "";
        input.placeholder.GetComponent<Text>().text = "Enter a " + w[currentWordIndex]; //change placeholder
        input.ActivateInputField();//let the blinker goes to the next one for inputfield
    }
    private void makeSelected()
    {
        input.ActivateInputField();
    }
    private void Start()
    {
        Invoke("makeSelected", 0.1f);
    }

    public void OnSaidStart()
    {
        input.text = "start";
        z = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("return") || z == true)//when in the input field, the user typed enter
        {
            word.text = "Welcome to MadLib";
            if (input.text.ToLower() == "start" && state == false) // if the input is equal to start then do the following
            {
                SSStart();
                askToEnter();
                state = true;
            }
            else if(state == true)
            {
                if (currentWordIndex <= w.Count())
                {
                    inputed.Add(input.text);
                    currentWordIndex++;
                    askToEnter();
                }
                else
                {
                    PrintStory();
                }
            }
        }
        z = false;

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
    }
}
