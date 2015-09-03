using UnityEngine;
using System.Collections;

public class Fleet
{
	public float _date { get; private set; }
	public string _player { get; private set; }
	public Ship[] _ships { get; private set; }
}