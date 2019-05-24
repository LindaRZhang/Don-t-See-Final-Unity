using UnityEngine;
/* Linda Rong Zhang
*  This file is for camera following the player
*/
public class CameraFollowCharacter : MonoBehaviour
{
    public Transform player; //get like the transform or position of character
                             //if there is no offset then it is 1st person perspective
    void Update()
    {
        transform.position = player.position;
        transform.Rotate(0f, 0f, transform.eulerAngles.z * -1);//it will position the camera back down, cancels out
    }
}
