﻿using UnityEngine;
using System.Collections;

public class GlobeEarthWin : MonoBehaviour {

	private Quaternion WinPosX;
	private Quaternion WinPosY;

	// Use this for initialization
	void Start () {
		WinPosX.y = gameObject.transform.rotation.y;
		WinPosX.x = 1;
		WinPosY.x = gameObject.transform.rotation.x;
		WinPosY.y = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Mousex: " + Quaternion.Angle (WinPosX, gameObject.transform.rotation));
		//Debug.Log ("Mousey: " + Quaternion.Angle (WinPosY, gameObject.transform.rotation));
		if (Quaternion.Angle (WinPosX, gameObject.transform.rotation) > 105 && 
		    Quaternion.Angle (WinPosX, gameObject.transform.rotation) < 135 &&
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) > 125 && 
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) < 160){
			StartCoroutine (WinWaitTime (3));
		}
	}

	IEnumerator WinWaitTime(int wtime){
		yield return new WaitForSeconds (wtime);
		if (Quaternion.Angle (WinPosX, gameObject.transform.rotation) > 105 && 
		    Quaternion.Angle (WinPosX, gameObject.transform.rotation) < 135 &&
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) > 125 && 
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) < 160)
			gameObject.GetComponent<NormalLevel>().havewon = true;
		else
			gameObject.GetComponent<NormalLevel>().havewon = false;
	}
}
