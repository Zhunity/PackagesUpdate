using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Property : Member
{
	PropertyInfo propertyInfo;

	public Property(Type belongType, string name)
	{
		propertyInfo = belongType.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		this.name = name;
		type = propertyInfo.PropertyType;
	}

	public override object GetValue()
	{
		if(belong == null)
		{
			Debug.LogError("can not find " + name);
		}
		return propertyInfo.GetValue(belong);
	}

	public void ShowValue()
	{
		Debug.Log(name + " : " + GetValue());
	}
}
