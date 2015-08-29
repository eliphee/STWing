using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("captainsList")]
public class CaptainCollection {
	
	[XmlArray("captains")]
	[XmlArrayItem("captain")]
	public List<CaptainClass> captainClass = new List<CaptainClass>();
	
	public static CaptainCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CaptainCollection));
		
		XmlReader reader = XmlReader.Create(path);

		CaptainCollection captains = (CaptainCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return captains;
	}
}