using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Cameralvlselect : MonoBehaviour, IComparer {
	
	private GameObject[] Levels;
	private int Where = 0;
	private float savedy;
	// Use this for initialization

	int IComparer.Compare( System.Object x, System.Object y) {
		return((new CaseInsensitiveComparer ()).Compare (((GameObject)x).name, ((GameObject)y).name));	
	}

	void Start () {
		Debug.Log (GameControl.control.Mode);
        Levels = GameObject.FindGameObjectsWithTag("Level");
		IComparer myComparer = new Cameralvlselect ();
		Array.Sort (Levels, myComparer);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.D))
        {
            if (Where < 3)
			{
				Where++;
				savedy = gameObject.transform.position.y;
				gameObject.transform.position = new Vector3(Levels[Where].transform.position.x, savedy, Levels[Where].transform.position.z);
			}
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Where > 0)
            {
				Where--;
				savedy = gameObject.transform.position.y;
				gameObject.transform.position = new Vector3(Levels[Where].transform.position.x, savedy, Levels[Where].transform.position.z);
            }
        }
		if (Input.GetKeyDown (KeyCode.Return)) {
			//Application.LoadLevel(Level[Where].name);
		}
	}

	void LoadProfile()
	{
		if (GameControl.control.Mode == 0) {
			//unlock everything
		} 
		else if (GameControl.control.Mode == 1) {
			GameControl.control.Load();
		}
	}
}