using UnityEngine;
using System.Collections;

public class Cameralvlselect : MonoBehaviour {

   private GameObject[] ArrayLevel;
   private int Where = 0;
	// Use this for initialization
	void Start () {
        ArrayLevel = GameObject.FindGameObjectsWithTag("Level");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.D))
        {
            if (Where > )
            Where++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Where > 0)
            {
                Where--;
            }
        }
	}
}
