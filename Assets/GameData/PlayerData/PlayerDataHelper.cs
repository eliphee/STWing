using UnityEngine;
using System.Collections;

public class PlayerDataHelper : MonoBehaviour {

	// 
	public void savePlayerFleet (string name, float date, int[][] shipFleet) {



		/*PlayerPrefs.SetString("playerName", name);
		PlayerPrefs.SetFloat("saveDate", date);
		for (int i = 1; i <= shipFleet.Length; i++)
		{
			for (int y = 1; y <= shipFleet[i].Length; y++)
			{
				string _xi = i;
				string _xy = y;
				if(i <= 9)
					_xi = "0"+i;
				if(y <= 9)
					_xy = "0"+y;

				PlayerPrefs.SetInt(_xi+_xy, shipFleet[i]);
			}
		}

		PlayerPrefs.GetInt(0101);*/
	}
	
	// 
	public Fleet loadPlayerFleet () {
		Fleet x = new Fleet();
		return x;
	}
}
