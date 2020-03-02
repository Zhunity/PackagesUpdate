using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageWindow : Member
{
	const string packageDetailsName = "packageDetails";
	PackageDetails packageDetails;

	public PackageWindow(Type belongType) : base(belongType)
	{
		packageDetails = new PackageDetails(this, packageDetailsName);
	}
}
