using System;
using UnityEngine;
/* Linda Rong Zhang
*  This file change camera position 
*  Citation: https://www.youtube.com/watch?v=BzBIK4_WSJY
*/
public class MouseCameraMove : MonoBehaviour
{

    public Camera eyes;
    public float sensativity = 3;
    CharacterController controller;
    float mouseX;
    float mouseY;
    float mouseFB; //front and back of mouse
    float mouseLR; //left right mouse moving
    float speed = 4;
    public Transform player;
    public AudioSource chara;//bumping
    public AudioSource h;//walking
   
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;//cursor disappear, press escape and ull see cursor
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall")
        {
            h.Stop();
            chara.Play();
        }

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
     
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            h.Play();
        }
            if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)){
                h.Stop();
        }
    }
}
