using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class Property : Member
{
	public PropertyInfo propertyInfo;

	public Property(Class belongMember, string name) : base(belongMember, name)
	{
	}

	public Property(Type belongType, string name) : base(belongType, name)
	{		
	}

	public override void SetValue(object value)
	{
		propertyInfo.SetValue(belong, value);
	}

	/// <summary>
	/// 数组会有问题
	/// 如RPackageItem.Item
	/// 类型是UnityEngine.UIElements.VisualElement Item [Int32]
	/// 修改方法：object value = info.GetValue(instance, new object[] { 0 });
	/// TODO 看看怎么判断是数组
	/// </summary>
	/// <returns></returns>
	public override object GetValue()
	{
		// TODO static可以不用判断
		//if (belong == null)
		//{
		//	Debug.LogError("can not find " + name);
		//	return null;
		//}
		return propertyInfo.GetValue(belong);
	}

	protected override void SetInfo(Type belongType, string name)
	{
		propertyInfo = belongType.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
	}

	protected override void SetType()
	{
		if(propertyInfo == null)
		{
			Debug.LogError("can not find " + name);
			return;
		}
		type = propertyInfo.PropertyType;
	}
}
