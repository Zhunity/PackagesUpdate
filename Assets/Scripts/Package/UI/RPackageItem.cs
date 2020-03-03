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
		// object value = info.GetValue(instance, new object[] { 0 });
		Debug.Log(Item.propertyInfo);

	}

	protected override void OnSetInstance()
	{
		
	}
}
