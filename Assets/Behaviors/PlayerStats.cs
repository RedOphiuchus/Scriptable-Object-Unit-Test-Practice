using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	[SerializeField]
	private IntReference maxHP;
	[SerializeField]
	private IntReference hp;
	// Use this for initialization

	void Start()
	{
		hp.Value = maxHP.Value;
	}


}
