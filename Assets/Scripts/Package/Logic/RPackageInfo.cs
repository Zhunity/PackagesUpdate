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
		var obj = GetAll.Invoke();
		var array = obj as Array;
		// 53？
		Debug.Log(array.Length);
		foreach(var item in array)
		{
			var package = new RPackageInfo(this.type);
			package.SetInstance(item);
			
		}
	}

	public RPackageInfo(Type type) : base(type)
	{
	}

	protected override void OnSetInstance()
	{
		Field m_DisplayName = new Field(this, "m_DisplayName");
		m_DisplayName.SetBelong(this);
		string displayName = m_DisplayName.GetValue().ToString();

		Field m_Versions = new Field(this, "m_Versions");
		m_Versions.SetBelong(this);
		m_Versions.ShowMembersValue(displayName);
	}
}
