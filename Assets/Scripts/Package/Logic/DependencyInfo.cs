using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyInfo : Class
{
	Property version;
	Property nameP;

	public DependencyInfo(Type type) : base(type)
	{
		version = new Property(this, "version");
		this.nameP = new Property(this, "name");
	}

	public void ShowValue()
	{
		Debug.Log(nameP.GetValue() + "  " + version.GetValue());
	}
}
