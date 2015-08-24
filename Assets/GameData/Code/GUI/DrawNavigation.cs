using UnityEngine;
using System.Collections;

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
	
	// Use this for initialization
	void Start ()
	{
		panelMovement = GameObject.Find ("Panel Movement");
		GameObject newArrow = GameObject.Instantiate (arrowUp);
		newArrow.transform.SetParent (panelMovement.transform);
		RectTransform newArrow_rt = newArrow.GetComponent<RectTransform>();
		newArrow_rt.anchoredPosition = new Vector2 (-75.5f, 68.7f);
		Debug.Log (newArrow.transform.parent.name + " -- " + newArrow.transform.position.x + "," + newArrow.transform.position.y + "," + newArrow.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
