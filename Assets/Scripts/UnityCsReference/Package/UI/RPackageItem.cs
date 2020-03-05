using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPackageItem : Class
{

	Property Item;  // UnityEngine.UIElements.VisualElement Item [Int32]
	IPackage package;
	IPackageVersion targetVersion;
	IPackageVersion selectedVersion;

	public RPackageItem(Type type) : base(type)
	{
		// 索引器
		Item = new Property(this, "Item");
		package = new IPackage(this, "package");
		targetVersion = new IPackageVersion(this, "targetVersion");
		selectedVersion = new IPackageVersion(this, "selectedVersion");
	}

	protected override void OnSetInstance()
	{
	}
}
