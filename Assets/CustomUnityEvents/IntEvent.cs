using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//A class that inherets a version of UnityEvent that takes one integer as an argument.
//We do this so that the event can be serialized from the editor.
[System.Serializable]
public class IntEvent : UnityEvent<int> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
