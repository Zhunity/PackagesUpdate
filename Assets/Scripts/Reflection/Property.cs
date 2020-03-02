using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class Property : Member
{
	PropertyInfo propertyInfo;

	public Property(Member belongMember, string name) : base(belongMember, name)
	{
	}

	public Property(Type belongType, string name) : base(belongType, name)
	{		
	}

	public override object GetValue()
	{
		if(belong == null)
		{
			Debug.LogError("can not find " + name);
			return null;
		}
		return propertyInfo.GetValue(belong);
	}

	public void ShowValue()
	{
		Debug.Log(name + " : " + GetValue());
	}

	protected override void SetInfo(Type belongType, string name)
	{
		propertyInfo = belongType.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
	}

	protected override void SetType()
	{
		type = propertyInfo.PropertyType;
	}
}
