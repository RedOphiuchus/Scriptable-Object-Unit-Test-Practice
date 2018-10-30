using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable 
{
	int GetMaxHealth();
	int GetHealth();
	int GetPower();
	GameEvent onDamageEvent();
}
