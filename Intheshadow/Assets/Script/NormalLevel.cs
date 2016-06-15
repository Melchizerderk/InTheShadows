﻿using UnityEngine;
using System.Collections;

public class NormalLevel : MonoBehaviour {

	private Quaternion WinPosX;
	private Quaternion WinPosY;
	private bool havewon = false;
	public GameObject LvlCanvas;
	
	void Start () {
		WinPosY.x = gameObject.transform.rotation.x;
		WinPosY.y = 1;
		WinPosX.x = 1;
		WinPosX.y = gameObject.transform.rotation.y;
		LvlCanvas.GetComponent<CanvasGroup>().alpha = 0;
		LvlCanvas.GetComponent<CanvasGroup>().interactable = false;
		LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
			transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
		if (Quaternion.Angle (WinPosY, gameObject.transform.rotation) < 10) {
			StartCoroutine(WinWaitTime(3));
			if (havewon == true)
			{
				LvlCanvas.GetComponent<CanvasGroup>().alpha = 1;
				SaveProfile();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("LevelSelect");
		}
	}
	
	IEnumerator WinWaitTime(int wtime){
		yield return new WaitForSeconds (wtime);
		if (Quaternion.Angle (WinPosY, gameObject.transform.rotation) < 10)
			havewon = true;
		else
			havewon = false;
	}
	
	void SaveProfile()
	{
		if (GameControl.control.Mode == 1) {
			if (GameControl.control.PlayerLevel == 0)
			{
				GameControl.control.PlayerLevel = 1;
				GameControl.control.Save();
			}
		}
	}
}
