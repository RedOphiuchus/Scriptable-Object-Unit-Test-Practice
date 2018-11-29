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
        UpdateBar();
        if (Physics.Raycast(ray, out hit)) {
            SetTestBehaviours(hit.transform.gameObject.GetComponents<MonoBehaviour>());
            SetTarget();
        }
		else
		{
			target = null;
		}
	}

    public void SetTestBehaviours(MonoBehaviour[] newBehaviours)
    {
        testBehaviours = newBehaviours;
    }

    public void SetTarget()
    {
        bool found = false;
        if (target != null)
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
                break;
            }
        }
        if (!found)
        {
            target = null;
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
