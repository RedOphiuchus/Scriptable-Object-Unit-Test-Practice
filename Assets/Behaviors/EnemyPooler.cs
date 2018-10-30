using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour {

	public ObjectPool EnemyPool;

	public FloatReference RespawnTime;
	// Use this for initialization

	public void SpawnNewEnemy()
	{
		Invoke("spawnLater", RespawnTime.Value);
	}

	private void spawnLater()
	{
		EnemyPool.CreateObject();
	}
}
