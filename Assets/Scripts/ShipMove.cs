using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour
{
//	private string[, ,] movementPattern = new string[]
//	{
//		{ "1", "left_bank", "green" },
//		{ "1", "right_bank", "green" },
//		{ "2", "forward", "green" },
//		{ "2", "left_bank", "white" },
//		{ "2", "left_turn", "white" },
//		{ "2", "right_bank", "white" },
//		{ "2", "right_turn", "white" },
//		{ "3", "forward", "green" },
//		{ "3", "left_bank", "white" },
//		{ "3", "left_turn", "white" },
//		{ "3", "right_bank", "white" },
//		{ "3", "right_turn", "white" },
//		{ "4", "forward", "white" },
//		{ "5", "forward", "white" },
//		{ "6", "forward", "white" }
//	};

	public GameObject debugCenter; //for debuging
	public float radius; // 1 Unit = 1 cm ! d(Base)=4
	public float angle;
	public float secPerDeg;

	private Ray ray;
	private bool move;                                                                                                                                           
	private Vector3 m_centerPosition;
	private float m_initial_radius;
	private float m_degrees;

	public bool debug_move;

	void OnMouseDown()
	{
		if (!move) {
			move = debug_move;
			if (angle == 0) {

			}
			else {
				m_degrees = 0.0f;
				m_centerPosition = GetMovementAxis(angle, radius);
				if (angle > 0) {
					m_initial_radius = -transform.rotation.eulerAngles.y; //m_initial_radius = 90.0f - transform.rotation.eulerAngles.y;
				}
				else {
					m_initial_radius = transform.rotation.eulerAngles.y - 90.0f;
				}
			}
		}
	}

	Vector3 GetMovementAxis(float angle, float radius)
	{
		Vector3 direction;
		if (angle > 0) {
			direction = Vector3.left;
		} else {
			direction = Vector3.right;
		}
		ray.direction = transform.rotation * direction;
		ray.origin = transform.position;
		return ray.GetPoint (radius);
	}

	void Start()
	{
		ray = new Ray ();
	}
	
	void Update()
	{
		// Update degrees
		if (move) 
		{
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

	void moveCurve()
	{
		float angleAbs = Mathf.Abs(angle);
		float degreesPerSecond = angleAbs / secPerDeg;
		if (m_degrees < angleAbs) {
			m_degrees = m_degrees + (Time.deltaTime * degreesPerSecond);
			
			float radians = (m_initial_radius + m_degrees) * Mathf.Deg2Rad;
			// Offset on circle
			Vector3 offset;
			if (angle > 0) {
				offset = new Vector3 (radius * Mathf.Cos (radians), 0.0f, radius * Mathf.Sin (radians));
				transform.position = m_centerPosition + offset;
				transform.Rotate (0.0f, -(Time.deltaTime * degreesPerSecond), 0.0f);
			} else {
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

	/* 
	 * Method to move the ship straight forward
	 */
	void moveStraight ()
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