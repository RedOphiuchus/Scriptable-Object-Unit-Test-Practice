﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolReference {

	[SerializeField]
	private bool UseConstant = true;
	[SerializeField]
	private BoolVariable val;
	[SerializeField]
	private bool constVal;

    public BoolReference()
    {
        UseConstant = true;
        constVal = false;
    }

    public BoolReference(BoolVariable value)
    {
        UseConstant = false;
        val = value;
    }

	public bool Value
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
