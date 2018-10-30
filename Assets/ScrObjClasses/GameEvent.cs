using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
