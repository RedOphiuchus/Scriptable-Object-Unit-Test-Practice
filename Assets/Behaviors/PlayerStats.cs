using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public GameEvent Lose;
	
	[SerializeField]
	private IntReference maxHP;
	[SerializeField]
	private IntReference hp;
	// Use this for initialization

	void Start()
	{
		hp.Value = maxHP.Value;
	}

	public void TakeDamage(int damage)
	{
		if((hp.Value -= damage) <= 0)
		{
			Lose.Raise();
		}
	}
}
