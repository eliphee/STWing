using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;

public class ShipColl {

	public List<ShipClass> shipClass = new List<ShipClass>();

	public static ShipColl Load(string path)
	{
		ShipColl ships = new ShipColl();
		
		XmlReader reader = XmlReader.Create(path);
		ShipClass ship;
		
		while (reader.Read())
		{
			if (reader.NodeType == XmlNodeType.Element && reader.Name == "ship")
			{
				if (reader.HasAttributes)
				{
					//ship = new ShipClass();
					//ship.id = Convert.ToInt32(reader.GetAttribute("id"));
					
					
					//ships.shipClass.Add (ship);
				}
				
			}
		}

		reader.Close();
		
		return ships;
	}
}