using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;

public class testbefueller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerDataHelper test = new PlayerDataHelper();
		List<XElement> testFleet = test.loadFleets();
		List<XElement> testShip = test.loadShips("2");
		List<XElement> testCard = test.loadCards("4", "1");

		Debug.Log (testFleet[0].Attribute("name").Value);
		Debug.Log (testShip[0].Attribute("shipID").Value);
		Debug.Log (testCard[0].Attribute("cardID").Value);


	}

}
