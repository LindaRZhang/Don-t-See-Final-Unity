using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congrat : MonoBehaviour
{
    public AudioSource Cheer;
    // Start is called before the first frame update
    void Start()
    {
        Cheer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Sound()
    {
        Cheer.Play();
    }

}
