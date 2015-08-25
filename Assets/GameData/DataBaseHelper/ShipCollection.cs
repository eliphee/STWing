using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("shipsAlt")]
public class ShipCollection {

	[XmlArray("ships")]
	[XmlArrayItem("ship")]
	public List<ShipClass> shipClass = new List<ShipClass>();

	public static ShipCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(ShipCollection));

		StringReader reader = new StringReader(path);

		reader.Read();
		
		ShipCollection ships = serializer.Deserialize(reader) as ShipCollection;

		reader.Close();
		
		return ships;
	}
}