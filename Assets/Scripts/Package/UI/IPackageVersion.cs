using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 显示选中package的信息
/// </summary>
public class IPackageVersion : Property
{
	public Property displayName;
	public Property description;
	public Property versionId;
	public Property dependencies;
	public Property resolvedDependencies;
	static bool show = true;

	public IPackageVersion(Class belongMember, string name) : base(belongMember, name)
	{
		displayName = new Property(this, "displayName");
		versionId = new Property(this, "versionId");
		//dependencies = new Property(this, "dependencies");
		//resolvedDependencies = new Property(this, "resolvedDependencies");
		
	}

	protected override void OnSetBelong()
	{

		Debug.Log(belong);
		//foreach(var item in dependencies.GetValue() as object[])
		//{
		//	Debug.Log(item);
		//}
	}
}
