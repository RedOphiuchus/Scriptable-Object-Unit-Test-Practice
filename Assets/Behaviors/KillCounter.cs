using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {
	public IntReference kills;
	public void incrementKillCount()
	{
		++kills.Value;
		transform.GetChild(1).GetComponent<Text>().text = kills.Value.ToString();
	}

	public void OnDestroy()
	{
		kills.Value = 0;
	}
}
