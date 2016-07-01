using UnityEngine;
using System.Collections;

public class Level1Script : MonoBehaviour {

	// Use this for initialization
	private Quaternion WinPos;
	private bool havewon = false;
	public GameObject LvlCanvas;

	void Start () {
		WinPos.x = gameObject.transform.rotation.x;
		WinPos.y = 1;
		LvlCanvas.GetComponent<CanvasGroup>().alpha = 0;
		LvlCanvas.GetComponent<CanvasGroup>().interactable = false;
		LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
			transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
		if (Quaternion.Angle (WinPos, gameObject.transform.rotation) < 10) {
			StartCoroutine(WinWaitTime(3));
			if (havewon == true)
			{
				LvlCanvas.GetComponent<CanvasGroup>().alpha = 1;
				LvlCanvas.GetComponent<CanvasGroup>().interactable = true;
				LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
				if (GameControl.control.Mode == 1 && GameControl.control.WichLevel == GameControl.control.PlayerLevel)
					GameControl.control.LvlGotCompleted = true;
				SaveProfile();
			}
		}
		if (Input.GetKeyDown (KeyCode.Delete)) {
			Application.LoadLevel("LevelSelect");
		}
	}

	IEnumerator WinWaitTime(int wtime){
		yield return new WaitForSeconds (wtime);
		if (Quaternion.Angle (WinPos, gameObject.transform.rotation) < 10)
			havewon = true;
		else
			havewon = false;
	}

	void SaveProfile()
	{
		if (GameControl.control.Mode == 1) {
			if (GameControl.control.PlayerLevel == GameControl.control.PlayerLevel)
			{
				GameControl.control.PlayerLevel = 1;
				GameControl.control.Save();
			}
		}
	}
}