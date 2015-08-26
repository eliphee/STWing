using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("shipAbilities")]
public class ShipAbilityCollection {
	
	[XmlArray("shipAbility")]
	[XmlArrayItem("shipSpecial")]
	public List<ShipAbilityClass> shipAbilityClass = new List<ShipAbilityClass>();
	
	public static ShipAbilityCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(ShipAbilityCollection));
		
		XmlReader reader = XmlReader.Create(path);
		
		reader.Read();
		
		ShipAbilityCollection shipSpecial = (ShipAbilityCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return shipSpecial;
	}
}