
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
//Citation https://www.youtube.com/watch?v=RDkDXZ8P1bg&t=116s

public class textToSpeech : MonoBehaviour
{
    public InputField input;
    public AudioSource _audio;
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();//gets the source
    }
    
    IEnumerator DownloadTheAudio(){
        Regex rgx = new Regex("\\s+");
        string result = rgx.Replace(input.placeholder.GetComponent<Text>().text, "+");

        string textToSpeechvar = "http://api.voicerss.org/?key=<d00c47fd4e7e4f219959c3f0886e8130>&hl=en-us&src="+result;
        WWW www = new WWW(textToSpeechvar);
        yield return www;
        _audio.clip = www.GetAudioClip(false,true,AudioType.MPEG);
        _audio.Play();
    }

    public void OnEnter()
    {
        GameObject mad = GameObject.Find("Text");
        madlib other = (madlib)mad.GetComponent(typeof(madlib));
        other.z = true;
        StartCoroutine(DownloadTheAudio());

    }
}
