using UnityEngine;
using System.Collections;
using System;
using System.Xml;

namespace AssemblyCSharp
{
	public class Ship
	{
		public struct Maneuver
		{
			int speed;
			string bearing;
			string difficulty;
		};


		// Ship Identification
		public string shipName { get; private set; }
		public string shipClass { get; private set; }
		public string shipFaction { get; private set; }
		public bool unique { get; private set; }

		// Primary Stats
		public int weapon;
		public int agility;
		public int hull;
		public int hullCurrent;
		public int shields;
		public int shieldsInactive;
		public int shieldsCurrent;

		// Costs
		public int squadronPoints;

		// Upgrade Slots
		public int upgradeSlotsCrew;
		public int upgradeSlotsTech;
		public int upgradeSlotsWeapons;
		public int upgradeSlotsBorg;
		public int upgradeSlotsFighter;

		// Action Bar
		//private List<Action> shipActionBar;


		public Maneuver[] maneuvers { get; private set; }

		public Ship ()
		{
			// Load initial ship

		}

//		public void AddShield (int amount);
//		public void RemoveShield (int amount);
//		public void DisableShield (int amount);

	}
}

