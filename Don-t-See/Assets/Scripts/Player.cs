using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public string level; // Saving the level

	public void SavePlayer(){
		SaveSystem.SaveData(this);
	}

	public void LoadPlayer(){
		PlayerData data = SaveSystem.LoadData();
		Vector3 position;
		position.x = data.playerPosition[0];
		position.y = data.playerPosition[1];
		position.z = data.playerPosition[2];

		transform.position = position;

	}
}
