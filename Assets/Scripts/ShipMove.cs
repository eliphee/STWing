using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour
{
//	public GameObject debugCenter; //for debuging
//	public float radius; // 1 Unit = 1 cm ! d(Base)=4
//	public float angle;
//	public float secPerDeg;

	private float radius;		// for Bank/Turn maneuver only
	private float angle;		// for Bank/Turn maneuver only
	private float distance;		// for Straight/ComeAbout/FullAstern maneuvers only
	private float secPerDeg;

	private Ray ray;
	private bool move;                                                                                                                                           
	private Vector3 m_centerPosition;
	private float m_initial_radius;
	private float m_degrees;

	void Start()
	{
		ray = new Ray ();
	}
	
	void Update()
	{
		Debug.Log (move);
		// Update degrees
		if (move)
		{
			Debug.Log (move);
			if (angle == 0)
			{
				moveStraight();
			}
			else
			{
				moveCurve();
			}
		}
	}

	// -----------------------------------------------------------------------------------------------------------
	//  Public methods
	// -----------------------------------------------------------------------------------------------------------


	/// <summary>
	/// Move the ship according to the specified maneuver.
	/// </summary>
	/// <param name="maneuver">Maneuver.</param>
	public void Move(Ship.Maneuver maneuver)
	{
		if (maneuver.bearing != "" && maneuver.difficulty != "")
		{
			Move (maneuver.speed, maneuver.bearing, maneuver.difficulty);
		}
		else
		{
			string retMsg = "Movement skipped due to empty maneuver values: ";
			if (maneuver.bearing == "") retMsg = retMsg + "bearing, ";
			if (maneuver.difficulty == "") retMsg = retMsg + "difficulty, ";
			Debug.Log(retMsg);
			return;
		}
	}

	/// <summary>
	/// Move the ship according to the specified speed, bearing and difficulty.
	/// </summary>
	/// <param name="speed">Speed.</param>
	/// <param name="bearing">Bearing.</param>
	/// <param name="difficulty">Difficulty.</param>
	public void Move(int speed, string bearing, string difficulty)
	{
		// Calculate movement variables from parameters

		// For Straight/ComeAbout/FullAstern maneuvers:
		//   Determine flight distance from 'speed' parameter
		// For Bank/Turn maneuvers:
		//   Determine turning angle and circle radius from 'bearing' and 'speed' parameter
		switch (bearing)
		{
			case "Straight":
				angle = 0.0f;
				radius = 0.0f;
				distance = 10.0f * speed;
				break;
			case "ComeAbout":
				angle = 0.0f;
				radius = 0.0f;
				distance = 10.0f * speed;
				break;
			case "FullAstern":
				angle = 0.0f;
				radius = 0.0f;
				distance = 10.0f * speed;
				break;
			case "LeftBank":
				angle = 45.0f;
				radius = 10.5f + (3.75f * (speed - 1));
				distance = 0.0f;
				break;
			case "LeftTurn":
				angle = 90.0f;
				radius = 3.4f + (2.8f * (speed -1));
				distance = 0.0f;
				break;
			case "RightBank":
				angle = -45.0f;
				radius = 10.5f + (3.75f * (speed - 1));
				distance = 0.0f;
				break;
			case "RightTurn":
				angle = -90.0f;
				radius = 3.4f + (2.8f * (speed -1));
				distance = 0.0f;
				break;
			default:
				Debug.Log ("Movement skipped due to not recognized parameter(bearing): '" + bearing + "'");
				return;
		}
		Debug.Log ("angle:" + angle + " // radius: " + radius + " // distance: " + distance);
		// Flight time
		secPerDeg = 1;

		// Initiate movement
		if (!move)
		{
			move = true;
			if (angle == 0)
			{
				
			}
			else
			{
				m_degrees = 0.0f;
				m_centerPosition = GetMovementAxis(angle, radius);
				if (angle > 0)
				{
					m_initial_radius = -transform.rotation.eulerAngles.y; //m_initial_radius = 90.0f - transform.rotation.eulerAngles.y;
				}
				else
				{
					m_initial_radius = transform.rotation.eulerAngles.y - 90.0f;
				}
			}
		}
	}


//	void OnMouseDown()
//	{
//		if (!move)
//		{
//			move = true;
//			if (angle == 0)
//			{
//
//			}
//			else
//			{
//				m_degrees = 0.0f;
//				m_centerPosition = GetMovementAxis(angle, radius);
//				if (angle > 0)
//				{
//					m_initial_radius = -transform.rotation.eulerAngles.y; //m_initial_radius = 90.0f - transform.rotation.eulerAngles.y;
//				}
//				else
//				{
//					m_initial_radius = transform.rotation.eulerAngles.y - 90.0f;
//				}
//			}
//		}
//	}

	// -----------------------------------------------------------------------------------------------------------
	//  Private methods
	// -----------------------------------------------------------------------------------------------------------


	/// <summary>
	/// Calculates the center of the circle to move along for banks/turns.
	/// </summary>
	/// <returns>The movement axis.</returns>
	/// <param name="angle">Angle.</param>
	/// <param name="radius">Radius.</param>
	private Vector3 GetMovementAxis(float angle, float radius)
	{
		Vector3 direction;
		if (angle > 0)
		{
			direction = Vector3.left;
		}
		else
		{
			direction = Vector3.right;
		}
		ray.direction = transform.rotation * direction;
		ray.origin = transform.position;
		return ray.GetPoint (radius);
	}


	/// <summary>
	/// Moves the curve.
	/// </summary>
	private void moveCurve()
	{
		float angleAbs = Mathf.Abs(angle);
		float degreesPerSecond = angleAbs / secPerDeg;
		if (m_degrees < angleAbs)
		{
			m_degrees = m_degrees + (Time.deltaTime * degreesPerSecond);
			
			float radians = (m_initial_radius + m_degrees) * Mathf.Deg2Rad;
			// Offset on circle
			Vector3 offset;
			if (angle > 0)
			{
				offset = new Vector3 (radius * Mathf.Cos (radians), 0.0f, radius * Mathf.Sin (radians));
				transform.position = m_centerPosition + offset;
				transform.Rotate (0.0f, -(Time.deltaTime * degreesPerSecond), 0.0f);
			}
			else
			{
				offset = new Vector3 (radius * Mathf.Sin (radians), 0.0f, radius * Mathf.Cos (radians));
				transform.position = m_centerPosition + offset;
				transform.Rotate (0.0f, Time.deltaTime * degreesPerSecond, 0.0f);
			}
		}
		else
		{
			move = false;
		}
	}


	/// <summary>
	/// Method to move the ship straight forward
	/// </summary>
	private void moveStraight ()
	{

		//UNDER CONSTRUCTION! 


		Vector3 offset;
		
		offset = new Vector3 (0.0f, 0.0f, radius);
		
		transform.position = m_centerPosition + offset;

		move = false;

		/*Rigidbody shipBody = GetComponent<Rigidbody> ();

		Vector3 targetPosition = shipBody.position + move;
		float moveSpeed = 5.0f;    
		

		shipBody.position = Vector3.MoveTowards(shipBody.position, targetPosition, moveSpeed * Time.deltaTime); */ 

	}
}