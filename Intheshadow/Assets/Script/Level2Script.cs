using UnityEngine;
using System.Collections;

public class Level2Script : MonoBehaviour {

	private Quaternion WinPos;
	private bool havewon = false;
	public GameObject LvlCanvas;
	
	void Start () {
		WinPos.x = 1;
		WinPos.y = gameObject.transform.rotation.x;
		LvlCanvas.GetComponent<CanvasGroup>().alpha = 0;
		LvlCanvas.GetComponent<CanvasGroup>().interactable = false;
		LvlCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1))
			transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
		Debug.Log (Quaternion.Angle (WinPos, gameObject.transform.rotation));
		if (Quaternion.Angle (WinPos, gameObject.transform.rotation) > 85 && Quaternion.Angle (WinPos, gameObject.transform.rotation) < 100) {
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
		if (Quaternion.Angle (WinPos, gameObject.transform.rotation) > 85 && Quaternion.Angle (WinPos, gameObject.transform.rotation) < 100)
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
