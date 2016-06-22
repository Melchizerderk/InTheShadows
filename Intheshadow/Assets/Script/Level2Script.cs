using UnityEngine;
using System.Collections;

public class Level2Script : MonoBehaviour {

	private Quaternion WinPosX;
	private Quaternion WinPosY;
	private bool havewon = false;
	public GameObject LvlCanvas;
	
	void Start () {
		WinPosX.y = gameObject.transform.rotation.y;
		WinPosX.x = 1;
		WinPosY.x = gameObject.transform.rotation.x;
		WinPosY.y = 1;
		LvlCanvas.GetComponent<CanvasGroup>().alpha = 0;
		LvlCanvas.GetComponent<CanvasGroup>().interactable = false;
		LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftShift)) {
			transform.Rotate (Input.GetAxis ("Mouse Y"), 0, 0, Space.World);
		} 
		else if (Input.GetMouseButton (0) && !(Input.GetKey (KeyCode.LeftShift))) {
			transform.Rotate (0, Input.GetAxis ("Mouse X"), 0, Space.World);
		}
		Debug.Log (Quaternion.Angle (WinPosX, gameObject.transform.rotation));
		Debug.Log (Quaternion.Angle (WinPosY, gameObject.transform.rotation));
		if (Quaternion.Angle (WinPosX, gameObject.transform.rotation) > 85 && 
		    Quaternion.Angle (WinPosX, gameObject.transform.rotation) < 100 &&
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) > 160) {
			StartCoroutine(WinWaitTime(3));
			if (havewon == true)
			{
				LvlCanvas.GetComponent<CanvasGroup>().alpha = 1;
				LvlCanvas.GetComponent<CanvasGroup>().interactable = true;
				LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
				SaveProfile();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("LevelSelect");
		}
		if (Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel (Application.loadedLevelName);
	}
	
	IEnumerator WinWaitTime(int wtime){
		yield return new WaitForSeconds (wtime);
		if (Quaternion.Angle (WinPosX, gameObject.transform.rotation) > 85 && 
		    Quaternion.Angle (WinPosX, gameObject.transform.rotation) < 100 &&
		    Quaternion.Angle (WinPosY, gameObject.transform.rotation) > 170)
			havewon = true;
		else
			havewon = false;
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
