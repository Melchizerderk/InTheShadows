using UnityEngine;
using System.Collections;
using System;

public class LevelState : MonoBehaviour {

	// Use this for initialization
	private int state;
	public int lvlid;
	MeshRenderer[] Symbol;
	MeshRenderer ActiveSymbol;

	void Start () {
		Symbol = GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer symbol in Symbol) {
			if (symbol.tag != "Level")
				symbol.enabled = false;
		}
		if (GameControl.control.Mode == 0) {
			ActiveSymbol = transform.FindChild ("Open").gameObject.GetComponent<MeshRenderer> ();
			ActiveSymbol.enabled = true;
			state = 0;
		} 
		else {
			if (lvlid < GameControl.control.PlayerLevel) {
				ActiveSymbol = transform.FindChild ("Done").gameObject.GetComponent<MeshRenderer> ();
				ActiveSymbol.enabled = true;
				state = 1;
			} 
			else if (lvlid == GameControl.control.PlayerLevel) {
				ActiveSymbol = transform.FindChild ("Open").gameObject.GetComponent<MeshRenderer> ();
				ActiveSymbol.enabled = true;
				state = 0;
			}
			else if (lvlid > GameControl.control.PlayerLevel) {
				ActiveSymbol = transform.FindChild ("Closed").gameObject.GetComponent<MeshRenderer> ();
				ActiveSymbol.enabled = true;
				state = -1;
			}
		}
		Rotate (state);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Rotate(int state)
	{
		if (state == 1)
				transform.Rotate (0, 0, 180);
		if (state == 0)
				transform.Rotate (0, 0, 90);
	}
}