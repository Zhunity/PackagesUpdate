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
		type = propertyInfo.PropertyType;
		ShowMembers();
	}

	public void ShowValue()
	{
		var target = propertyInfo.GetValue(belong);
		Debug.Log(target.GetType());
	}
}
