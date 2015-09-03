using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("techUpgrades")]
public class TechCollection {
	
	[XmlArray("techUpgrade")]
	[XmlArrayItem("tech")]
	public List<TechClass> techClass = new List<TechClass>();
	[XmlArray("abilities")]
	[XmlArrayItem("ability")]
	public List<AbilityClass> abilityClass = new List<AbilityClass>();
	
	public static TechCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(TechCollection));
		
		XmlReader reader = XmlReader.Create(path);
		
		reader.Read();
		
		TechCollection techs = (TechCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return techs;
	}
}