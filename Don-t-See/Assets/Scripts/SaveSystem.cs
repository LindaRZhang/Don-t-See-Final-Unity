using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/* Instruction for using this save system:
 * in the script you should find three scripts: Player, PlayerData, and this file, SaveSystem
 * in the Player class in Player script, there's 2 method: SavePlayer and LoadPlayer
 * as it sounds, you invoke saving by invoking the SavePlayer method, loading by LoadPlayer method
 * saving will create a binary file named player.save, containing player last position, and the scence which the player was in when invoked
 * loading will ONLY change the position of the player according to the player.save file
 * if you want to access the scene create a variable like this:
 * 	PlayerData newVariable = SaveSystem.LoadData();
 * the scene should be accessable through newVariable.level (it is a string)
 */


public static class SaveSystem {

	public static string SavePath (){
		string path = Application.persistentDataPath + "/player.save";
		return path;
	}
	

	public static void SaveData (Player player){
		BinaryFormatter binary = new BinaryFormatter();
		string path = SavePath();
		FileStream stream = new FileStream(path, FileMode.Create);
		PlayerData data = new PlayerData(player);
		binary.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadData() {
		string path = SavePath();
		if (File.Exists(path)) {
			BinaryFormatter binary = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			PlayerData data = binary.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;
		}
		else {
			Debug.LogError("Save file not found in " + path);
			return null;
		}


	}
}
