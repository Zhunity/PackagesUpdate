using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class PackageDetails : Property
{
	IPackageVersion displayVersion;
	IPackageVersion targetVersion;

	public PackageDetails(Type belongType, string name) : base(belongType, name)
	{
		displayVersion = new IPackageVersion(this, "displayVersion");
		//displayVersion.SetBelong(GetValue());
		
	}

	public void SetWindow(Object window)
	{
		SetBelong(window);
		displayVersion.ShowValue();
	}
}
