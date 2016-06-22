using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Cameralvlselect : MonoBehaviour, IComparer {
	
	private GameObject[] Levels;
	[HideInInspector]
	public int Where = 0;
	private float savedy;
	private int maxlevel = 3;
	private NavMeshAgent agent;
	// Use this for initialization

    //Comparaison maison
	int IComparer.Compare( System.Object x, System.Object y) {
		return((new CaseInsensitiveComparer ()).Compare (((GameObject)x).name, ((GameObject)y).name));	
	}

	void Start () {
		//Debug.Log (GameControl.control.Mode);
        Levels = GameObject.FindGameObjectsWithTag("Level");
		IComparer myComparer = new Cameralvlselect ();
		Array.Sort (Levels, myComparer);
        LoadProfile();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.D))
        {
            if (Where < maxlevel)
			{
				Where++;
				GetComponent<NavMeshAgent>().destination = Levels[Where].transform.position;
			}
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Where > 0)
            {
				Where--;
				GetComponent<NavMeshAgent>().destination = Levels[Where].transform.position;
            }
        }
		if (Input.GetKeyDown (KeyCode.Return)) {
			GameControl.control.WichLevel = Where;
			Application.LoadLevel(Levels[Where].name);
		}
	}

	void LoadProfile()
	{
		if (GameControl.control.Mode == 0) {
            maxlevel = Levels.Length - 1;
		} 
		else if (GameControl.control.Mode == 1) {
			GameControl.control.Load();
            maxlevel = GameControl.control.PlayerLevel;
		}
	}
}