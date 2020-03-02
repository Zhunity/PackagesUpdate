using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// package管理界面
/// </summary>
public class PackageWindow : Member
{
	const string packageDetailsName = "packageDetails";
	PackageDetails packageDetails;
	PackageList packageList;

	public PackageWindow(Type belongType) : base(belongType)
	{
		packageDetails = new PackageDetails(this, packageDetailsName);
		packageList = new PackageList(this, "packageList");
	}
}
