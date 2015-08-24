using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayHit;

		if (Physics.Raycast (ray.origin, ray.direction, out rayHit, Mathf.Infinity))
		{
		//	Debug.Log ("Mouse Click!");
		}
	}
}
