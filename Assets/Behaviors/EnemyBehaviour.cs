using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that governs a single enemies behavior.
public class EnemyBehaviour : MonoBehaviour, ITargetable, IDamageable {
	private int hp;

	private int hurtAmnt;

	public IntReference maxHP;
	public IntReference damage;

	public FloatReference attackSpeed;

	public ObjectPool enemyObjectPool;

	private float remainingTime = 0.0f;

	private GameEvent onDamage;

	public GameEvent onDeath;
	
	void Start()
	{
		hurtAmnt = Random.Range(50,80);
		onDamage = ScriptableObject.CreateInstance<GameEvent>();
		if(enemyObjectPool)
		{
			enemyObjectPool.Add(this);
		}
		else 
		{
			Debug.Log("No enemy pool.");
		}
	}

	void OnDestroy()
	{
		if(enemyObjectPool)
		{
			enemyObjectPool.Remove(this);
		}
		else 
		{
			Debug.Log("No enemy pool.");
		}
	}

	void OnEnable()
	{
		hp = maxHP.Value;
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
			onDeath.Raise();
			NormalColor();
			StopAllCoroutines();
			gameObject.SetActive(false);
		}
		
		onDamage.Raise();
	}


	public void Flash()
	{
		GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
		StartCoroutine(ResetColor());
	}

	IEnumerator ResetColor()
	{
		yield return new WaitForSeconds(.3f);
		NormalColor();
	}

	private void NormalColor()
	{
		GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
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
