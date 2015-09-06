using UnityEngine;
using System.Collections;

public class UpgradeFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Modifies the captain skill of target ship.
	/// </summary>
	/// <returns><c>true</c>, if captain skill was modified, <c>false</c> otherwise.</returns>
	/// <param name="target">Target ship.</param>
	/// <param name="modType">Modification type (Set, Add, Reduce).</param>
	/// <param name="modAmount">Operation value.</param>
	public void ModifyCaptainSkill(Ship target, string modType, int modAmount)
	{
		switch (modType)
		{
			case "Set":
				target.captainSkill = modAmount;
				break;
			case "Add":
				target.captainSkill = target.captainSkill + modAmount;
				break;
			case "Reduce":
				if (target.captainSkill - modAmount < 0)
				{
					target.captainSkill = 0;
				}
				else
				{
					target.captainSkill = target.captainSkill - modAmount;
				}
				break;
			default:
				Debug.LogError("Modification type '" + modType + "' not recognized.");
				break;
		}

	}

	/// <summary>
	/// Applies damage to target ships.
	/// As long as shields are present on the target ship, they absorb hits and then criticals until they collapse.
	/// If no shields are active, the criticals and then the hits are applied to the ships hull.
	/// </summary>
	/// <param name="target">Target ship.</param>
	/// <param name="amountHit">Number of HITS to deal.</param>
	/// <param name="amountCrit">Number of CRITICALS to deal.</param>
	public void DealDamage(Ship target, int amountHit, int amountCrit)
	{
		// Reduce shield value by Hits
		while (amountHit > 0 && target.shieldsCurrent > 0)
		{
			target.shieldsCurrent--;
			amountHit--;
		}

		// Reduce shield value by Criticals
		while (amountCrit > 0 && target.shieldsCurrent > 0)
		{
			target.shieldsCurrent--;
			amountHit--;
		}

		// Reduce hull value by Criticals
		while (amountCrit > 0 && target.hullCurrent > 0)
		{
			target.hullCurrent--;
			amountCrit--;
			AddCriticalEffect(target);
		}

		// Reduce hull value by Hits
		while (amountHit > 0 && target.hullCurrent > 0)
		{
			target.hullCurrent--;
			amountHit--;
		}
	}


	public void DealDamageOnAttackRoll(Ship target, int rollAmount,  string rollTrigger, bool inflictCrits)
	{
		int resultHit, resultCrit, resultBS, resultMiss;
		int amountHit = 0, amountCrit = 0;
		Dice d = new Dice ();
		d.RollAttack (rollAmount, out resultHit, out resultCrit, out resultBS, out resultMiss);

		if (rollTrigger.Contains ("Hit"))
		{
			// Add rolled HIT-results to total HIT-damage
			amountHit += resultHit;
		}

		if (rollTrigger.Contains("Critical"))
		{
			if (inflictCrits)
			{
				// Add rolled CRITICAL-results to total CRITITAL-damage
				amountCrit += resultCrit;
			}
			else
			{
				// Add rolled CRITIAL-results to total HIT-damage (convert CRITICALS to HITS)
				amountHit += resultCrit;
			}
		}

		if (rollTrigger.Contains("BattleStations"))
		{
			// Add rolled BATTLESTATIONS-results to total HIT-damage
			amountHit += resultBS;
		}

		// Call DealDamage-method for damage handling
		DealDamage (target, amountHit, amountCrit);
	}

	/// <summary>
	/// Adds a critical damage effect to the target ship.
	/// </summary>
	/// <param name="target">Target.</param>
	public void AddCriticalEffect(Ship target)
	{

	}
}
