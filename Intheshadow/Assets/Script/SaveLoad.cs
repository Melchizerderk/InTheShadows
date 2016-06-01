using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoad {

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);


		/*instance de type que l'on veut sauvegarder, je devrais faire une classe pour pouvoir facilement rajouter des stats
		 si j'ai envie, mais dans un premier temps elle ne contiendra que le niveau d'access*/
		bf.Serialize (file, /*data*/);
		file.Close ();

	}

	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			/*object du type qui a ete sauvegarde precedemment*/ = bf.Deserialize(file);
			file.Close();
		}
	}
}
