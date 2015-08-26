using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("weaponUpgrades")]
public class WeaponCollection {
	
	[XmlArray("weapons")]
	[XmlArrayItem("weapon")]
	public List<WeaponClass> weaponClass = new List<WeaponClass>();
	
	public static WeaponCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(WeaponCollection));
		
		XmlReader reader = XmlReader.Create(path);
		
		reader.Read();
		
		WeaponCollection weapons = (WeaponCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return weapons;
	}
}