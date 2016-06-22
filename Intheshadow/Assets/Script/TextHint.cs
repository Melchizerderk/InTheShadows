using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<Cameralvlselect>().Where == 0)
			GetComponent<Text> ().text = "It's tea time!";
		else if (GetComponentInParent<Cameralvlselect>().Where == 1)
			GetComponent<Text> ().text = "People say I never forget";
		else if (GetComponentInParent<Cameralvlselect>().Where == 2)
			GetComponent<Text> ().text = "Spin the world round";
		else if (GetComponentInParent<Cameralvlselect>().Where == 3)
			GetComponent<Text> ().text = "The Answer";
	}
}
