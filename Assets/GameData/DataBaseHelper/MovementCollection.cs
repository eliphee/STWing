using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("patternList")]
public class MovementCollection {
	
	[XmlArray("patterns")]
	[XmlArrayItem("pattern")]
	public List<MovementClass> movementClass = new List<MovementClass>();
	
	public static MovementCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(MovementCollection)); //CreateOverrider();
		
		XmlReader reader = XmlReader.Create(path);
		
		MovementCollection movement = (MovementCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return movement;
	}
}