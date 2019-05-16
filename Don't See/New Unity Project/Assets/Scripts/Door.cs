using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
	// Start is called before the first frame update
	public UnityEvent userInputOpen = new UnityEvent();
	public UnityEvent userInputClosed = new UnityEvent();
	public Transform doorTransform;
	void Start() {
		userInputOpen.AddListener(OpenDoor);
		userInputClosed.AddListener(CloseDoor);
	}

    	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("o") && userInputOpen != null){
			userInputOpen.Invoke();
		}
		if (Input.GetKeyDown("c") && userInputClosed != null){
			userInputClosed.Invoke();
		}
	}
	void OpenDoor(){
		doorTransform.localRotation = Quaternion.Euler(0f, 90, 0f);
	}
	void CloseDoor(){
		doorTransform.localRotation = Quaternion.Euler(0f, 0, 0f);
	}
}
