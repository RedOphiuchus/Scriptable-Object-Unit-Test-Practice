using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Listens for a game event to be raised. It first adds itself to that game events list, then its appropriate
//OnEventRaised function will be called when it is raised.
public class GameEventListener : MonoBehaviour {
	public GameEvent gameEvent;
	public UnityEvent response;

	public IntEvent intResponse;

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

	public void OnEventRaised(int value)
	{
		intResponse.Invoke(value);
	}
}
