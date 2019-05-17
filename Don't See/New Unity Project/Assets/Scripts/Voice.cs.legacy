using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using System.Collections.Generic;

//citation https://www.youtube.com/watch?v=29vyEOgsW8s
public class voice : MonoBehaviour
{
    public Transform t;
    public Transform player;
    private KeywordRecognizer key;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private object myGameObject;
    public bool sitting = false;
    public Rigidbody rb;
    private void Start()
    {
        actions.Add("foward",foward);//add word to dict and then call function if they hear that word "foward"
        actions.Add("back", back);
        actions.Add("left", left);
        actions.Add("right", right);
        actions.Add("start", MadlibStart);
        actions.Add("sit", sit);
        actions.Add("stand", stand);
        actions.Add("chair", chair);

        key = new KeywordRecognizer(actions.Keys.ToArray());//object
        key.OnPhraseRecognized += Recgon;//when OnPhraseRecognize event occur it will call function Recgon
        key.Start(); //start picking up voice
    }
    public void sit()
    {
        player.position = new Vector3(2.45f, 2.57f, -3.06f);
        sitting = true;
    }
    public void stand()
    {
       player.position = new Vector3(0.732f,1.43f,-2.640f);
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
        madlib other = (madlib)mad.GetComponent(typeof(madlib));
        other.z = true;
        other.OnSaidStart();
    }
    private void foward()
    {
        t.Translate(0, 0, 2);
    }
    private void back()
    {
        t.Translate(0, 0, -2);
    }
    private void left()
    {
        t.Translate(-2, 0, 0);
    }
    private void right()
    {
        t.Translate(2, 0, 0);
    }
}
