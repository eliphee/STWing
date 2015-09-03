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

	public int RollAttack() 
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

	public int RollDefense()
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
}