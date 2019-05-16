using UnityEngine;
//citation:https://www.youtube.com/watch?v=ORD7gsuLivE
//citation:https://www.youtube.com/watch?v=BzBIK4_WSJY
public class move : MonoBehaviour
{
    public Transform t;
    public Rigidbody rb;
    public Transform cameraa;
   
   
    //Time.deltaTime help everythsing look the same on all system
    void FixedUpdate() {
        Vector3 f = cameraa.forward;//foward direction of camera
        Vector3 r = cameraa.right;//right direction of camera
        f.y = 0; //y position of camera will be 0
        r.y = 0;
        f = f.normalized;//normalize always
        r = r.normalized;


        t.position += (f * Input.GetAxis("Vertical") + r * Input.GetAxis("Horizontal")) * Time.deltaTime * 5;
        //position of object moving in the direction of camera

    }
}
