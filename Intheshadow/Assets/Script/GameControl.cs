using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using System;

public class GameControl : MonoBehaviour {

	// Use this for initialization
	public static GameControl control;

	public int Mode = -1;
	public int PlayerLevel;
	public int WichLevel;

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.Level = PlayerLevel;

		bf.Serialize (file, data);
		file.Close ();
	}
	
	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			PlayerLevel = data.Level;
			Debug.Log(data.Level);
		}
	}
}

//Classe contenant la data a sauvegarde
[Serializable]
class PlayerData
{
	public int Level;	
}