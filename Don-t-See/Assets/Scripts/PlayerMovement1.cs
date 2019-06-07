using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement1 : MonoBehaviour {

	
	public Rigidbody rb;

	public float forwardForce = 2000f;	//forward force
	public float sidewaysForce = 200f;  //sideways force
    
	void FixedUpdate ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            SceneManager.LoadScene("Menu_bar");
        }
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))	
		{
			
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) 
		{
			
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		
	}
}
