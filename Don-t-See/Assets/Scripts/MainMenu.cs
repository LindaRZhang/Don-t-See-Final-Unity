using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Kirthik Sai - wrote most of the script
 * Linda Rong Zhang - implement scene switching using the script and added button
*  This file is for Main Menu script
*  Citation: https://www.youtube.com/watch?v=BzBIK4_WSJY
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
    public bool menu = true;

    public void PlayMaze()
    {
        Debug.Log("maze");
        //Application.Quit();
        SceneManager.LoadScene(Maze);
    }
    public void PlayMadlib()
    {
        Debug.Log("madlib");
        Application.Quit();
        SceneManager.LoadScene(Madlib);
    }
    public void PlayRace()
    {
        Debug.Log("race");
        Application.Quit();
        SceneManager.LoadScene(Race);
    }
    public void PlayQuiz()
    {
        Debug.Log("quiz");
        Application.Quit();
        SceneManager.LoadScene(Quiz);
    }
    public void PlayBrick()
    {
        Debug.Log("brick");
        Application.Quit();
        SceneManager.LoadScene(Brick);
    }
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
