using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("crews")]
public class CrewCollection {
	
	[XmlArray("crew")]
	[XmlArrayItem("member")]
	public List<CrewClass> crewClass = new List<CrewClass>();
	
	public static CrewCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CrewCollection)); //CreateOverrider();

		XmlReader reader = XmlReader.Create(path);
		
		CrewCollection crews = (CrewCollection)serializer.Deserialize(reader);
	
		reader.Close();

		return crews;
	}
}