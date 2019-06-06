using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
