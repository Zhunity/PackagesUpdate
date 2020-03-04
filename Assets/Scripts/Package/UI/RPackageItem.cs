using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPackageItem : Class
{

	Property Item;  // UnityEngine.UIElements.VisualElement Item [Int32]
	public RPackageItem(Type type) : base(type)
	{
		Item = new Property(this, "Item");
		

	}

	protected override void OnSetInstance()
	{
		Debug.Log(Item.GetValue());
	}
}
