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
        //Application.LoadLevel();
    }

    public void OnNormalClick()
    {
        Debug.Log("test");
        //
    }
}
