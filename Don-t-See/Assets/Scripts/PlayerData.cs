﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
	public float[] playerPosition;
	public bool levelUnlocked;
	public string obstacle;

	
	public PlayerData (Player player) {
		obstacle = player.destroyTag;
		playerPosition = new float[3];
		playerPosition[0] = player.transform.position.x;
		playerPosition[1] = player.transform.position.y;
		playerPosition[2] = player.transform.position.z;
	}

}
