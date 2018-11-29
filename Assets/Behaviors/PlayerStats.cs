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
        InitializeFullHealth();
	}

    public void Construct(IntReference newMaxHP, IntReference newHP )
    {
        maxHP = newMaxHP;
        hp = newHP;
    }

    public void InitializeFullHealth()
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
