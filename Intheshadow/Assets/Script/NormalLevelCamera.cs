using UnityEngine;
using System.Collections;
using System;

public class NormalLevelCamera : MonoBehaviour {

	// Use this for initialization
	private GameObject[] Elements;
	private int elemnbr;
	private int i = 0;
	public GameObject LvlCanvas;

	void Start () {
		Elements = GameObject.FindGameObjectsWithTag("Element");
		elemnbr = Elements.Length;
		LvlCanvas.GetComponent<CanvasGroup>().alpha = 0;
		LvlCanvas.GetComponent<CanvasGroup>().interactable = false;
		LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("LevelSelect");
		}
		if (Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel (Application.loadedLevelName);
		while (i < elemnbr) {
			if (Elements[i].gameObject.GetComponent<NormalLevel>().havewon == true)
				i++;
			else
			{
				i = 0;
				break;
			}
		}
		if (i == elemnbr)
		{
			LvlCanvas.GetComponent<CanvasGroup> ().alpha = 1;
			LvlCanvas.GetComponent<CanvasGroup> ().interactable = true;
			LvlCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			//SaveProfile ();
		}
	}

	void SaveProfile()
	{
		if (GameControl.control.Mode == 1) {
			if (GameControl.control.PlayerLevel == 1)
			{
				GameControl.control.PlayerLevel = 2;
				GameControl.control.Save();
			}
		}
	}
}
