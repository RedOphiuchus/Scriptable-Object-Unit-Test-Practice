using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatReference 
{
	[SerializeField]
	private bool UseConstant = true;
	[SerializeField]
	private FloatVariable val;
	[SerializeField]
	private float constVal;

    public FloatReference()
    {
        UseConstant = true;
        constVal = 0.0f;
    }

    public FloatReference(FloatVariable newVar)
    {
        UseConstant = false;
        val = newVar;
    }

	public float Value
	{
		get{return UseConstant ? constVal : val.value;}

		set{
			if(UseConstant)
				constVal = value;
			else
				val.value = value;
		}
	}
	
}
