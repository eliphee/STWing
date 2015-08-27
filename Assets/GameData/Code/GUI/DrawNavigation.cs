using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawNavigation : MonoBehaviour {

	/* x,y coords for creation of navigation gui grid (top-bottom, left to right)
	 * --------------------------------------------------------------------------
	 * rows (posY):  68.7,  44.0,  19.3, -5.4, -30.1, -54.8, -79.5	//24.7 distance
	 * cols (posX): -75.5, -50.8, -26.1, -1.4,  23.3,  48.0, 72.7	//24,7 distance
	 * 
	 * Rules for population of 7x7 grid with maneuvers:
	 * ------------------------------------------------
	 *  1) Columns are always populated with the same maneuver: from left to right (1-7):
	 *		1: Speed indicator (6 to -2), show only where maneuver exists for current ship,
	 *		   positive values in white, negative in grey without minus-sign
	 *		2: Left Turn
	 *		3: Left Bank
	 *		4: Straight / Full Astern
	 * 		5: Right Bank
	 *		6: Right Turn
	 *		7: Come About
	 *	2) Rows distinguish between ship speeds
	 *		- forward maneuvers
	 *			- are arranged from bottom to top with increading speed
	 *			- lowest forward speed starts at row 5 of 7 (with on exception) leaving the last to rows for backward maneuvers
	 *			- starting from the lowest speed, increase speed by 1 for every row rising to the top, no row may be omitted
	 *			- Exception: Ships with a maximum speed of 6 start at row 6 of 7 to leave enough rows for all forward maneuvers
	 *			- Bank and Turn maneuvers are not possible with speeds > 4
	 *		- backward maneuvers
	 *			- are arranged from top to bottom with increasing speed
	 *			- lowest reverse speed start at row 6 (see exception above)
	 *			- If rows 6 and 7 are free for reverse maneuvers and the ship only posesses a -2 maneuver, it is displayed in row 7
	 *			  this leads to an omitted row for reverse maneuvers
	 * 
	 * Further rules:
	 * 	- slower maneuvers (such with lower number) are more likely to be an easy (green) or normal (white) maneuver
	 *  - therefore a ship may never have maneuvers of same bearing which are easier in higher speeds
	 * 		example: it is impossible to have a white 3-turn but a red 2-turn
	 */

	public Canvas gui;
	private GameObject panelMovement;
	public GameObject arrowUp;
	public GameObject arrowComeabout;
	public GameObject arrowLeftBank;
	public GameObject arrowLeftTurn;
	public GameObject arrowRightBank;
	public GameObject arrowRightTurn;
	public GameObject arrowFullAstern;

	// Use this for initialization
	void Start ()
	{
		panelMovement = GameObject.Find ("Panel Movement");
//		GameObject newArrow = GameObject.Instantiate (arrowUp);
//		newArrow.transform.SetParent (panelMovement.transform);
//		RectTransform newArrow_rt = newArrow.GetComponent<RectTransform>();
//		newArrow_rt.anchoredPosition = new Vector2 (23.3f, 68.7f);
//		Debug.Log (newArrow.transform.parent.name + " -- " + newArrow.transform.position.x + "," + newArrow.transform.position.y + "," + newArrow.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{

//		<pattern id="8">
//			<maneuver speed="1" bearing="Straight" difficulty="green" />
//			<maneuver speed="1" bearing="LeftBank" difficulty="green" />
//			<maneuver speed="1" bearing="RightBank" difficulty="green" />
//			<maneuver speed="2" bearing="Straight" difficulty="green" />
//			<maneuver speed="2" bearing="LeftBank" difficulty="white" />
//			<maneuver speed="2" bearing="LeftTurn" difficulty="white" />
//			<maneuver speed="2" bearing="RightBank" difficulty="white" />
//			<maneuver speed="2" bearing="RightTurn" difficulty="white" />
//			<maneuver speed="3" bearing="Straight" difficulty="white" />
//			<maneuver speed="3" bearing="LeftBank" difficulty="white" />
//			<maneuver speed="3" bearing="LeftTurn" difficulty="red" />
//			<maneuver speed="3" bearing="RightBank" difficulty="white" />
//			<maneuver speed="3" bearing="RightTurn" difficulty="red" />
//			<maneuver speed="4" bearing="Straight" difficulty="white" />
//			<maneuver speed="-1" bearing="FullAstern" difficulty="red" />
//		</pattern>


		Ship.Maneuver[] debugManeuvers = new Ship.Maneuver[]
		{
			new Ship.Maneuver(1, "Straight", "green"),
			new Ship.Maneuver(1, "LeftBank", "green"),
			new Ship.Maneuver(1, "RightBank", "green"),
			new Ship.Maneuver(2, "Straight", "green"),
			new Ship.Maneuver(2, "LeftBank", "white"),
			new Ship.Maneuver(2, "LeftTurn", "white"),
			new Ship.Maneuver(2, "RightBank", "white"),
			new Ship.Maneuver(2, "RightTurn", "white"),
			new Ship.Maneuver(3, "Straight", "white"),
			new Ship.Maneuver(3, "LeftBank", "white"),
			new Ship.Maneuver(3, "LeftTurn", "red"),
			new Ship.Maneuver(3, "RightBank", "white"),
			new Ship.Maneuver(3, "RightTurn", "red"),
			new Ship.Maneuver(4, "Straight", "white"),
			new Ship.Maneuver(-1, "FullAstern", "red")
		};

		// Calculate BaseLine row
		int baseLine = GetBaseLine (debugManeuvers);

		foreach (Ship.Maneuver m in debugManeuvers)
		{
			DrawArrow (m.speed, baseLine, m.bearing, m.difficulty);
		}

	}

	/// <summary>
	/// Gets the base line.
	/// </summary>
	/// <returns>The base line.</returns>
	/// <param name="maneuvers">Maneuvers.</param>
	private int GetBaseLine(Ship.Maneuver[] maneuvers)
	{
		int baseLine = 5; //Standard baseline
		int maxSpeed = 1;

		foreach (Ship.Maneuver m in maneuvers)
		{
			if (m.speed > maxSpeed)
			{
				maxSpeed = m.speed;
			}
		}

		if (maxSpeed > 5)
		{
			baseLine = maxSpeed;
		}

		return baseLine;
	}

	/// <summary>
	/// Draws the arrow.
	/// </summary>
	/// <param name="speed">Speed.</param>
	/// <param name="baseLine">Base line.</param>
	/// <param name="bearing">Bearing.</param>
	/// <param name="difficulty">Difficulty.</param>
	private void DrawArrow(int speed, int baseLine, string bearing, string difficulty)
	{
		// Create new GameObject "Arrow"
		GameObject newArrow;
		float posX, posY;
		int row, col;

		// Load Arrow-image and determine column to insert into based on bearing
		switch (bearing)
		{
			case "Straight":
				newArrow = GameObject.Instantiate (arrowUp);
				col = 4;
				break;
			case "ComeAbout":
				newArrow = GameObject.Instantiate (arrowComeabout);
				col = 7;
				break;
			case "LeftBank":
				newArrow = GameObject.Instantiate (arrowLeftBank);
				col = 3;
				break;
			case "LeftTurn":
				newArrow = GameObject.Instantiate (arrowLeftTurn);
				col = 2;
				break;
			case "RightBank":
				newArrow = GameObject.Instantiate (arrowRightBank);
				col = 5;
				break;
			case "RightTurn":
				newArrow = GameObject.Instantiate (arrowRightTurn);
				col = 6;
				break;
			case "FullAstern":
				newArrow = GameObject.Instantiate (arrowFullAstern);
				col = 4;
				break;
			default:
				return;
		}

		// Determine coords based on input row and column
		if (speed > 0)
		{
			row = baseLine + 1 - speed;
		} 
		else
		{
			row = baseLine - speed;
		}
		
		posX = -100.2f + col * 24.7f;
		posY = 93.4f - row * 24.7f;

		// Colorize arrow based on difficulty
//		switch (difficulty)
//		{
//			case "green":
//				newArrow.GetComponent<Image>().color = Color.green;
//				break;
//			case "white":
//				newArrow.GetComponent<Image>().color = Color.white;
//				break;
//			case "red":
//				newArrow.GetComponent<Image>().color = Color.red;
//				break;
//			default:
//				return;
//		}

		// Attach new GameObject to Panel
		newArrow.transform.SetParent (panelMovement.transform);
		RectTransform newArrow_rt = newArrow.GetComponent<RectTransform>();
		newArrow_rt.anchoredPosition = new Vector2 (posX, posY);
	}

}
