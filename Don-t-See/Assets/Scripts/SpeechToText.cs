using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
/* Linda Rong Zhang
*  This file gets user voice commands and call corresponding function to execute
*  Speech to text 
*  citation https://www.youtube.com/watch?v=29vyEOgsW8s
*/
public class SpeechToText : MonoBehaviour
{
    public Transform t;
    public Transform player;
    private KeywordRecognizer key;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private object myGameObject;
    public bool sitting = false;
    public Rigidbody rb;
    public InputField input;
    private bool Foward = false;
    private bool Left = false;
    private bool Right = false;
    private bool Back = false;
    public MouseCameraMove MM;

    private void Start()
    {
        actions.Add("foward", foward);//add word to dict and then call function if they hear that word "foward"
        actions.Add("back", back);
        actions.Add("left", left);
        actions.Add("right", right);
        actions.Add("start", MadlibStart);
        actions.Add("sit", sit);
        actions.Add("stand", stand);
        actions.Add("chair", chair);
        actions.Add("clear", clear);
        actions.Add("enter", enter);
        actions.Add("stop", stop);
        actions.Add("help", help);

        key = new KeywordRecognizer(actions.Keys.ToArray());//object
        key.OnPhraseRecognized += Recgon;//when OnPhraseRecognize event occur it will call function Recgon
        key.Start(); //start picking up voice
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("w"))
        {
                Foward = false;
                Left = false;
                Right = false;
                Back = false;
        }
        if (Foward == true)
        {
            foward();
        }
        if (Left == true)
        {
            left();
        }
        if (Right == true)
        {
            right();
        }
        if(Back == true)
        {
            back();
        }
    }
    public void help()
    {
        MM.helps();
    }
    public void enter() {
        GameObject mad = GameObject.Find("Text");
        Madlib other = (Madlib)mad.GetComponent(typeof(Madlib));
        other.entera = true;
    }
    public void sit()
    {
        player.position = new Vector3(2.45f, 2.57f, -3.06f);
        sitting = true;
    }
    public void stand()
    {
        player.position = new Vector3(0.732f, 1.43f, -2.640f);
        sitting = false;
    }
    public void chair()
    {
        if (sitting == true)
        {
            stand();
        }
        else
        {
            sit();
        }
    }
    private void Recgon(PhraseRecognizedEventArgs speech)//recognize speech
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();//pass the speech in 
    }
    private void MadlibStart()
    {
        GameObject mad = GameObject.Find("Text");
        Madlib other = (Madlib)mad.GetComponent(typeof(Madlib));
        input.text = "start";
        other.Start2();
    }
    private void clear()
    {
        GameObject mad = GameObject.Find("Text");
        Madlib other = (Madlib)mad.GetComponent(typeof(Madlib));
        other.Clear();
    }
    private void foward()
    {
        Back = false;
        Left = false;
        Right = false;
        Foward = true;
        t.position = t.position + new Vector3(0, 0, 0.3f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Vector3 movement = new Vector3(MM.mouseLR * Time.deltaTime * 0.01f, 0, MM.mouseFB * Time.deltaTime * 0.01f);
        Vector3 gravity = new Vector3(0, (float)9.8, 0);
        if (collision.collider.tag == "wall")
        {
            if (Foward == true)
            {
                t.position = t.position - new Vector3(0, 0, 50);
            }
            if (Back == true)
            {
                t.position = t.position - ((transform.rotation * movement) - gravity);
            }
            if (Right == true)
            {
                t.position = t.position - new Vector3(50, 0, 0);
            }
            if (Left == true)
            {
                t.position = t.position - new Vector3(-50, 0, 0);
            }
        }
    }
    private void back()
    {
        Foward = false;
        Left = false;
        Right = false;
        Back = true;
        Vector3 movement = new Vector3(MM.mouseLR * Time.deltaTime * 0.01f, 0, MM.mouseFB * Time.deltaTime * 0.01f);
        Vector3 gravity = new Vector3(0, (float)9.8, 0);
        t.position = t.position + ((transform.rotation * movement) - gravity); //move in camera direction-gravity
    }
    private void left()
    {
        Foward = false;
        Back = false;
        Right = false;
        Left = true;
        t.position = t.position + new Vector3(-0.3f, 0, 0);
    }
    private void right()
    {
        Foward = false;
        Left = false;
        Back = false;
        Right = true;
        t.position = t.position + new Vector3(0.3f, 0, 0);
    }
    private void stop()
    {
        Foward = false;
        Left = false;
        Right = false;
        Back = false;
    }
}
