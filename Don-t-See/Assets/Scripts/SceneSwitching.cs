using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour {
	// One of the object must have RigidBody component
	// Both must have some sort of collider component
	// The input will be the scene name in string format, not the scene object itself
	// In order to switch, the scene in question must be loaded (or added in Build settings)
	public string sceneName;

	public void Start(){
		Debug.Log("Hi there");
	}
	void OnCollisionEnter(UnityEngine.Collision other){
		if (other.collider.tag == "Player"){
			SceneManager.LoadScene(sceneName);
		}
		Debug.Log("Collision?");
	}
}
