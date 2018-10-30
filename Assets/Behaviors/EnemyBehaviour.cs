using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ITargetable, IDamageable {
	private int hp;

	private int hurtAmnt;

	public IntReference maxHP;
	public IntReference damage;

	public FloatReference attackSpeed;

	private float remainingTime = 0.0f;

	private GameEvent onDamage;
	
	void Start()
	{
		hp = maxHP.Value;
		hurtAmnt = Random.Range(50,80);
		onDamage = ScriptableObject.CreateInstance<GameEvent>();
	}
	void Update()
	{
		remainingTime += Time.deltaTime;
		if(remainingTime > attackSpeed.Value)
		{
			//Do an attack.
			remainingTime -= attackSpeed.Value;
		}
	}

	public void TakeDamage(int damage)
	{
		if((hp -= damage) <= 0)
		{
			//Then perish
		}
		
		onDamage.Raise();
	}

	public int GetHealth()
	{
		return hp;
	}

	public int GetMaxHealth()
	{
		return maxHP.Value;
	}

	public int GetPower()
	{
		return damage.Value;
	}

	public GameEvent onDamageEvent()
	{
		return onDamage;
	}
	
}
