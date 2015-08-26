using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("captainUpgrades")]
public class CaptainUpgradeCollection {
	
	[XmlArray("captainUpgrade")]
	[XmlArrayItem("captainSpecial")]
	public List<CaptainUpgradeClass> captainUpgradeClass = new List<CaptainUpgradeClass>();
	
	public static CaptainUpgradeCollection Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(CaptainUpgradeCollection));
		
		XmlReader reader = XmlReader.Create(path);
		
		reader.Read();
		
		CaptainUpgradeCollection captainUpgrade = (CaptainUpgradeCollection)serializer.Deserialize(reader);
		
		reader.Close();
		
		return captainUpgrade;
	}
}