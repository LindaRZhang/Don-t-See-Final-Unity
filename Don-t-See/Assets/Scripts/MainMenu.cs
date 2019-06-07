using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Kirthik Sai - wrote most of the script
 * Linda Rong Zhang - implement scene switching using the script and added button
*  This file is for Main Menu script
*/
public class MainMenu : MonoBehaviour
{
    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public string Maze;
    public string Madlib;
    public string Quiz;
    //public string Race;
    public string Brick;
    public string Race;
    public bool menu = false;

    void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        Cursor.visible = true;
    }
    public void PlayMaze()
    {
        menu = true;
        Debug.Log("maze");
        SceneManager.LoadScene(Maze);
    }
    public void PlayMadlib()
    {
        menu = true;
        Debug.Log("madlib");
        SceneManager.LoadScene(Madlib);
    }
    public void PlayRace()
    {
        menu = true;
        Debug.Log("race");
        SceneManager.LoadScene(Race);
    }
    public void PlayQuiz()
    {
        menu = true;
        Debug.Log("quiz");
        SceneManager.LoadScene(Quiz);
    }
    public void PlayBrick()
    {
        menu = true;
        Debug.Log("brick");
        SceneManager.LoadScene(Brick);
    }
    public void Exit()
    {
        menu = true;
        Debug.Log("Quit");
        Application.Quit();
    }
}
