using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntReference
{
	[SerializeField]
	private bool UseConstant = true;
	[SerializeField]
	private IntVariable val;
	[SerializeField]
	private int constVal;

    public IntReference()
    {
        UseConstant = true;
        constVal = 0;
    }

    public IntReference(IntVariable newVar)
    {
        UseConstant = false;
        val = newVar;
    }

	public int Value
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
