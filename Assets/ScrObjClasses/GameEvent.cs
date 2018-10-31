using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A scriptable object event. Multiple scripts can reference the same event. Some will raise the event, 
//and when the event is raised, every script that is listening for the event will
//call some kind of function.
[CreateAssetMenu]
public class GameEvent : ScriptableObject 
{
	private List<GameEventListener> listeners = new List<GameEventListener>();

	public void Raise()
	{
		for(int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised();
		}
	}

	public void Raise(int value)
	{
		for(int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised(value);
		}
	}

	public void RegisterListener(GameEventListener newListener)
	{
		listeners.Add(newListener);
	}

	public void UnRegisterListener(GameEventListener oldListener)
	{
		int toRemove = listeners.IndexOf(oldListener);
		listeners[toRemove] = listeners[listeners.Count - 1];
		listeners.RemoveAt(listeners.Count - 1);
	}
}
