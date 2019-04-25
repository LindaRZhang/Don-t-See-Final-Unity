using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour {
	// Start is called before the first frame update
	public UnityEvent userInput = new UnityEvent();
	public Transform doorTransform;
	void Start() {
		userInput.AddListener(OpenDoor);	
	}

    	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("o") && userInput != null){
			userInput.Invoke();
		}
	}
	void OpenDoor(){
		doorTransform.localRotation = Quaternion.Euler(0f, 90, 0f);
	}
}
