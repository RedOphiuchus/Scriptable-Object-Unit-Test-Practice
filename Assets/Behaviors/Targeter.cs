using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour {
	private ITargetable target;
	public BoolReference isTargeting;

	private MonoBehaviour[] testBehaviours;

	private Camera myCamera;

	private RaycastHit hit;

	private Ray ray;

	public IntReference targetHP;

	public IntReference targetMaxHP;
	// Use this for initialization
	void Start () {
		myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
    	ray = myCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            testBehaviours = hit.transform.gameObject.GetComponents<MonoBehaviour>();
			bool found = false;
			if(target != null)
			{
					target.onDamageEvent().UnRegisterListener(GetComponent<GameEventListener>());
			}
			for (int i = 0; i < testBehaviours.Length; i++)
			{				
				if (testBehaviours[i] is ITargetable)
				{
					target = (ITargetable)testBehaviours[i];
					target.onDamageEvent().RegisterListener(GetComponent<GameEventListener>());
					found = true;
					UpdateBar();
					break;
				}
			}
			if(!found)
			{
				target = null;
				UpdateBar();
			}
            
            // Do something with the object that was hit by the raycast.
        }
		else
		{
			target = null;
			UpdateBar();
		}
	}

	public void UpdateBar()
	{
		if (target != null)
		{
			targetHP.Value = target.GetHealth();
			targetMaxHP.Value = target.GetMaxHealth();
			isTargeting.Value = true;
		}
		else
		{
			isTargeting.Value = false;
		}
	}
}
