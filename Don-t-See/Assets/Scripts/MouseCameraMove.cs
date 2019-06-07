using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* Linda Rong Zhang
*  This file is related to character's movenment and collision
*  Citation: https://www.youtube.com/watch?v=BzBIK4_WSJY
*/
public class MouseCameraMove : MonoBehaviour
{

    public Camera eyes;
    public float sensativity = 3;
    public CharacterController controller;
    public float mouseX;
    public float mouseY;
    public float mouseFB; //front and back of mouse
    public float mouseLR; //left right mouse moving
    public float speed = 2f;
    public Transform player;
    public AudioSource bump;//bumping
    public AudioSource bumpR;//rightbump
    public AudioSource bumpL;//leftbump
    public AudioSource h;//walking
    public AudioSource help;//help
    public MainMenu M;
    public Madlib Madlib;
    public Player playerData;

    private void Start()
    {
        h.loop = false;
        h.Stop();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;//cursor disappear, press escape and ull see cursor
    }
    public void helps()
    {
        help.Play();
    }
    void Update()
    {
        mouseFB = Input.GetAxis("Vertical");//vertical axis
        mouseLR = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * sensativity, 0);
        Vector3 movement = new Vector3(mouseLR * Time.deltaTime * speed, 0, mouseFB * Time.deltaTime * speed);
        Vector3 gravity = new Vector3(0, (float)9.8, 0);
        controller.Move((transform.rotation * movement) - gravity); //move in camera direction-gravity
        eyes.transform.Rotate(-mouseY * sensativity, 0, 0);
        if (Input.GetMouseButtonDown(1))
        {
            help.Stop();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) 
            || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("w"))
        {
            h.loop = true;
            h.Play();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d") || Input.GetKeyUp("w"))
        {
            h.loop = false;
            h.Stop();
        }
        if (Input.GetKeyDown("space"))
        {
            if (Madlib.madli != true)
            {
                helps();
            }
        }
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "clock")
        {
            Debug.Log("CollideClock");
            M.menu = false;
            Application.Quit();
	    playerData.SavePlayer();
            SceneManager.LoadScene("Madlib"); 
        }
        if (collision.collider.tag == "rabbit")
        {
            SceneManager.LoadScene("Maze-game");
        }
        if (collision.collider.tag == "wall")
        {
            Debug.Log("Collision");
            h.Stop();
            h.loop = false;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") )
            {
                bump.Stop();
                bumpR.Stop();
                bumpL.Play();

            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d") )
            {
                bump.Stop();
                bumpL.Stop();
                bumpR.Play();
            }
            else
            {
                bumpL.Stop();
                bumpR.Stop();
                bump.Play();
            }
        }

    }


}
