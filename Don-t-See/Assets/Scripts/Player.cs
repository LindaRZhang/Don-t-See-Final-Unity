using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public string destroyTag;
	public Object destroyable;
	void Start() {
		LoadPlayer();
	}
	public void SavePlayer(){
		SaveSystem.SaveData(this);
	}

	public void LoadPlayer(){
		PlayerData data = SaveSystem.LoadData();
		destroyable = GameObject.FindWithTag(data.obstacle);
		Vector3 position;
		GameObject.Destroy(destroyable);
		position.x = data.playerPosition[0] - 1;
		position.y = data.playerPosition[1];
		position.z = data.playerPosition[2] - 1;
		transform.position = position;

	}

	public void OnCollisionEnter(UnityEngine.Collision other) {
		destroyTag = other.collider.tag;
		Debug.Log(destroyTag);
	}
}
