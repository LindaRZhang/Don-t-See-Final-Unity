using UnityEngine;

public class followp1 : MonoBehaviour
{
    public Transform player; //get like the transform or position of character
                             //if there is no offset then it is 1st person perspective
    void Update()
    {
        transform.position = player.position;
        if (Input.GetKey("j"))//rotate left
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 90f);

        }
        if (Input.GetKey("k"))//rotate right
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 90f);

        }
        if (Input.GetKey("u"))//rotate down
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 90f);

        }
        if (Input.GetKey("i"))//rotate down
        {
            transform.Rotate(Vector3.left * Time.deltaTime * 90f);
        }
        transform.Rotate(0f, 0f, transform.eulerAngles.z * -1);//it will position the camera back down, cancels out
    }
}
