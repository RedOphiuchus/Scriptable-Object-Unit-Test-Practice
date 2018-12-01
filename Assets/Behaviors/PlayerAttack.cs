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

    public void Construct(IntReference power, FloatReference attackSpeed)
    {
        this.power = power;
        this.attackSpeed = attackSpeed;
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
                    AttackApplicableBehaviour(hit.transform.gameObject.GetComponents<MonoBehaviour>());
				}
			}
		}

		attackTimer += Time.deltaTime;
	}

    public void AttackApplicableBehaviour(MonoBehaviour[] potentials)
    {
        testBehaviours = potentials;
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
