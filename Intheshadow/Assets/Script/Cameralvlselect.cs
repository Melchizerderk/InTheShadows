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
	private bool CubeRotation = false;
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
		if (Levels [GameControl.control.WichLevel].gameObject.transform.FindChild ("Done").gameObject.GetComponent<MeshRenderer> ().enabled == true 
		    && GameControl.control.LvlGotCompleted == true && (GameControl.control.PlayerLevel - GameControl.control.WichLevel <= 1)) {
			StartCoroutine(RotationRoutine());
			CubeRotation = true;
			GameControl.control.LvlGotCompleted = false;
		}
		if (CubeRotation == true) {
			Levels[GameControl.control.WichLevel].gameObject.transform.Rotate(new Vector3(0,0,180), 90 * Time.deltaTime * 1f);
			if (GameControl.control.WichLevel < maxlevel)
			{
				Levels[GameControl.control.WichLevel + 1].gameObject.transform.Rotate(new Vector3(0,0,90), 45 * Time.deltaTime * 1f);
			}
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

	IEnumerator RotationRoutine()
	{
		yield return new WaitForSeconds (2);
		CubeRotation = false;
	}
}