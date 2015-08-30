using UnityEngine;
using System.Collections;

public class ManeuverHandler : MonoBehaviour {

	private int speed;
	private string bearing;
	private string difficulty;
	private GameObject targetObject;

	public void LoadPattern(int speed, string bearing, string difficulty, GameObject targetObject)
	{
		this.speed = speed;
		this.bearing = bearing;
		this.difficulty = difficulty;
		this.targetObject = targetObject;
	}
	
	public void Move()
	{
		//Debug.Log (speed + ", " + bearing + ", " + difficulty);
		this.targetObject.GetComponent<ShipMove>().Move(this.speed, this.bearing, this.difficulty);
	}
}