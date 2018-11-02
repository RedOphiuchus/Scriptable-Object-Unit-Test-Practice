using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that orders a group of enemies to attack in a simple pattern.
public class EnemyAttackPattern : MonoBehaviour {
	public FloatReference attackSpeed;

	public IntReference damage;

	public IntReference playerHP;

	public ObjectPool enemyPool;

	private WaitForSeconds waitTime;

	private int turn = 0;

	public GameEvent onAttack;
    

    // Use this for initialization
    void Start () {
		StartCoroutine(Attack());
	}
	
	IEnumerator Attack()
	{
		yield return new WaitForSeconds(attackSpeed.Value);
		if(enemyPool.list[turn].isActiveAndEnabled)
		{
			enemyPool.list[turn].Flash();
			onAttack.Raise(damage.Value);
		}
		turn = (turn + 1) % enemyPool.list.Count;
		StartCoroutine(Attack());
	}
}
