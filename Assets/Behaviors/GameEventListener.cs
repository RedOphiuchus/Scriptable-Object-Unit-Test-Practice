using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
	public GameEvent gameEvent;
	public UnityEvent response;

	public void OnEnable()
	{
		if(gameEvent)
		{
			gameEvent.RegisterListener(this);
		}
	}

	public void OnDisable()
	{
		if(gameEvent)
		{
			gameEvent.UnRegisterListener(this);
		}
	}

	public void OnEventRaised()
	{
		response.Invoke();
	}
}
