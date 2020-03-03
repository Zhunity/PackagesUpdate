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
		var info = Item.propertyInfo;
		Debug.Log(Item.propertyInfo + "\nName:\t\t" + info.Name + "\nReflectedType:\t" + info.ReflectedType + "\nMemberType:\t" + info.MemberType + "\nPropertyType:\t" + info.PropertyType + "\nDeclaringType:\t" + info.DeclaringType);

	}

	protected override void OnSetInstance()
	{
		
	}
}
