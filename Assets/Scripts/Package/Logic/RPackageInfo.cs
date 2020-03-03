using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class RPackageInfo : Member
{
	Method GetAll;
	public RPackageInfo(string type) : base(type)
	{
		GetAll = new Method(this, "GetAll");
		var item = GetAll.Invoke();
		var array = item as Array;
		// 53？
		Debug.Log(array.Length);
	}

	protected override void OnSetBelong()
	{
		
	}
}
