using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class PackageDetails
{
	const string PropertyName = "packageDetails";
	PropertyInfo packageDetails;
	Type packageDetailsType;
	Object window;


	public PackageDetails(Type windowType)
	{
		packageDetails = windowType.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		packageDetailsType = packageDetails.PropertyType;
		ShowMembers();
	}

	public void SetWindow(Object window)
	{
		this.window = window;
	}

	public void ShowValue()
	{
		var target = packageDetails.GetValue(window);
		Debug.Log(target.GetType());
	}

	private void ShowMembers()
	{
		var list = packageDetailsType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach (var item in list)
		{
			Debug.Log("Name:\t\t" + item.Name + "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
		}
	}
}
