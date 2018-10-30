using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	[SerializeField]
	private FloatReference attackSpeed;

	[SerializeField]
	private IntReference power;
	private RaycastHit hit;

	private Camera myCamera;

	private IDamageable recepient;

	private Ray ray;

	private MonoBehaviour[] testBehaviours;

	private float attackTimer;
	// Use this for initialization
	void Start () {
		myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			if (attackTimer >= attackSpeed.Value)
			{
				attackTimer = 0f;
				ray = myCamera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit)) {
            		testBehaviours = hit.transform.gameObject.GetComponents<MonoBehaviour>();
					for (int i = 0; i < testBehaviours.Length; i++)
					{				
						if (testBehaviours[i] is IDamageable)
						{
							recepient = (IDamageable)testBehaviours[i];
							recepient.TakeDamage(power.Value);
						}
					}
				}
			}
		}

		attackTimer += Time.deltaTime;
	}
}
