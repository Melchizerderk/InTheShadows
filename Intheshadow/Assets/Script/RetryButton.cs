using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {

	public void OnRetryClick()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
}