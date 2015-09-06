using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
	public const int AtkCrit 	= 3;
	public const int AtkHit 	= 2;
	public const int AtkBS 		= 1;
	public const int AtkMiss 	= 0;

	public const int DefEvade 	= 2;
	public const int DefBS 		= 1;
	public const int DefMiss 	= 0;

	/// <summary>
	/// Rolls one attack die.
	/// </summary>
	/// <returns>The attack die result.</returns>
	public int RollAttackDie() 
	{
		int result = Random.Range (1, 7);
		if (result < 3) {
			return Dice.AtkMiss;
		} else if (result >= 3 && result < 5) {
			return Dice.AtkBS;
		} else if (result >= 6 && result < 8) {
			return Dice.AtkHit;
		} else {
			return Dice.AtkCrit;
		}
	}

	/// <summary>
	/// Rolls one defense die.
	/// </summary>
	/// <returns>The defense die result.</returns>
	public int RollDefenseDie()
	{
		int result = Random.Range (1, 7);
		if (result < 4) {
			return Dice.DefMiss;
		} else if (result >= 4 && result < 7) {
			return Dice.DefBS;
		} else {
			return Dice.DefEvade;
		}
	}

	/// <summary>
	/// Rolls an amount of attack dice.
	/// </summary>
	/// <param name="rollAmount">Amount of dice to be rolled.</param>
	/// <param name="resultHit">Amount of HIT results.</param>
	/// <param name="resultCrit">Amount of CRIT results.</param>
	/// <param name="resultBS">Amount of BATTLESTATION results.</param>
	/// <param name="resultMiss">Amount of MISSES.</param>
	public void RollAttack(int rollAmount, out int resultHit, out int resultCrit, out int resultBS, out int resultMiss)
	{
		resultHit = 0;
		resultCrit = 0;
		resultBS = 0;
		resultMiss = 0;

		while (rollAmount > 0) {
			switch (RollAttackDie ()) {
			case AtkCrit:
				resultCrit++;
				break;
			case AtkHit:
				resultHit++;
				break;
			case AtkBS:
				resultBS++;
				break;
			case AtkMiss:
				resultMiss++;
				break;
			}
			rollAmount--;
		}
	}

	/// <summary>
	/// Rolls an amount of defense dice.
	/// </summary>
	/// <param name="rollAmount">Amount of dice to be rolled.</param>
	/// <param name="resultEvade">Amount of EVADE results.</param>
	/// <param name="resultBS">Amount of BATTLESTATION results.</param>
	/// <param name="resultMiss">Amount of MISSES.</param>
	public void RollDefense(int rollAmount, out int resultEvade, out int resultBS, out int resultMiss)
	{
		resultEvade = 0;
		resultBS = 0;
		resultMiss = 0;

		while (rollAmount > 0) {
			switch (RollDefenseDie ()) {
			case DefEvade:
				resultEvade++;
				break;
			case DefBS:
				resultBS++;
				break;
			case DefMiss:
				resultMiss++;
				break;
			}
			rollAmount--;
		}
	}
}