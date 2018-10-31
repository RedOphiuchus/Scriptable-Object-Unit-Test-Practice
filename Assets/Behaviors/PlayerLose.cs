using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLose : MonoBehaviour {

	public void Lose()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}
