using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Updates the killcount whenever an enemy is killed.
public class KillCounter : MonoBehaviour {
	public IntReference kills;

	public int goal;

	public GameEvent Win;
	public void incrementKillCount()
    {
        ++kills.Value;
        transform.GetChild(1).GetComponent<Text>().text = kills.Value.ToString();
        if (kills.Value == goal)
        {
            Win.Raise();
        }
    }

    public void OnDestroy()
	{
		kills.Value = 0;
	}
}
