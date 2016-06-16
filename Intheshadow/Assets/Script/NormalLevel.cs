using UnityEngine;
using System.Collections;

public class NormalLevel : MonoBehaviour {
	
	private bool selected = false;
	public GameObject Thisgameobject;
	private Vector3 target;
	[HideInInspector]
	public bool havewon = false;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f))
			{
				Debug.DrawLine(ray.origin, hit.point, Color.green);
				Debug.Log (hit.collider.name);
				if (hit.collider.name == Thisgameobject.transform.GetChild(0).name)
					selected = true;
				else
					selected = false;
			}
		}
		if (selected == true) {
			if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftShift)) {
				transform.Rotate (Input.GetAxis ("Mouse Y"), 0, 0, Space.World);
			} 
			else if (Input.GetMouseButton (0) && !(Input.GetKey (KeyCode.LeftShift)) 
			         && !(Input.GetKey(KeyCode.LeftControl)) && !(Input.GetKey(KeyCode.RightControl))) {
				transform.Rotate (0, Input.GetAxis ("Mouse X"), 0, Space.World);
			}
			else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl))
			{
				float ypos = Input.mousePosition.y;
				Vector3 target = new Vector3(transform.position.x, ypos, transform.position.z);
				if (Input.GetAxis("Mouse Y") > 0)
					transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
				if (Input.GetAxis("Mouse Y") < 0)
					transform.position = Vector3.MoveTowards(transform.position, target, -0.5f);
			}
			else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.RightControl))
			{
				float xpos = Input.mousePosition.x;
				Vector3 target = new Vector3(xpos, transform.position.y, transform.position.z);
				if (Input.GetAxis("Mouse X") > 0)
					transform.position = Vector3.MoveTowards(transform.position, target, 1f);
				if (Input.GetAxis("Mouse X") < 0)
					transform.position = Vector3.MoveTowards(transform.position, target, -1f);
			}
		}
	}

	//pour la base mousey > 160 mousey < 120 et > 80
}