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
		Debug.Log (i);
		Debug.Log (Elements [0].gameObject.GetComponent<NormalLevel> ().havewon == true);
		Debug.Log (Elements[1].gameObject.GetComponent<NormalLevel>().havewon == true);
		if (Input.GetKeyDown (KeyCode.Delete)) {
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
			if (Elements[0].gameObject.GetComponent<Transform>().position.x - Elements[1].gameObject.GetComponent<Transform>().position.x > -5 &&
			    Elements[0].gameObject.GetComponent<Transform>().position.x - Elements[1].gameObject.GetComponent<Transform>().position.x < 5 &&
			    Elements[0].gameObject.GetComponent<Transform>().position.y - Elements[1].gameObject.GetComponent<Transform>().position.y > -4 && 
			    Elements[0].gameObject.GetComponent<Transform>().position.y - Elements[1].gameObject.GetComponent<Transform>().position.y < 4)
			{
				LvlCanvas.GetComponent<CanvasGroup> ().alpha = 1;
				LvlCanvas.GetComponent<CanvasGroup> ().interactable = true;
				LvlCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				SaveProfile ();
			}
		}
	}

	void SaveProfile()
	{
		if (GameControl.control.Mode == 1) {
			if (GameControl.control.WichLevel == GameControl.control.PlayerLevel)
			{
				GameControl.control.PlayerLevel++;
				GameControl.control.Save();
			}
		}
	}
}
