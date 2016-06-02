using UnityEngine;
using System.Collections;

public class ButtonBehav : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDevClick()
    {
        Debug.Log("dev");
		GameControl.control.Mode = 0;
        Application.LoadLevel("LevelSelect");
    }

    public void OnNormalClick()
    {
        Debug.Log("test");
		GameControl.control.Mode = 1;
		Application.LoadLevel ("LevelSelect");
    }
}
