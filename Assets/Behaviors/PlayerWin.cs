using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public void Win()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		Time.timeScale = 0;
	}
}
