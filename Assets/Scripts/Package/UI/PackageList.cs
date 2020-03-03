using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 显示出来的package列表
/// </summary>
public class PackageList : Member
{
	Field m_PackageItemsLookup;
	Type packageItemType;
	Dictionary<string, RPackageItem> r_PackageItemsLookup = new Dictionary<string, RPackageItem>(); // 122个

	public PackageList(Member belongMember, string name) : base(belongMember, name)
	{
		m_PackageItemsLookup = new Field(this, "m_PackageItemsLookup");
		var arguments = m_PackageItemsLookup.GetGenericTypeArguments();
		r_PackageItemsLookup.Clear();
		packageItemType = arguments[1];
	}

	protected override void OnSetBelong()
	{
		r_PackageItemsLookup.Clear();
		IDictionary dict = m_PackageItemsLookup.Value as IDictionary;
		var iter = dict.GetEnumerator();
		while(iter.MoveNext())
		{
			RPackageItem item = new RPackageItem(packageItemType);
			item.SetInstance(iter.Value);
			r_PackageItemsLookup.Add(iter.Key.ToString(), item);
		}
		

		foreach(var item in r_PackageItemsLookup)
		{
			//Debug.Log(item.Key + "  " + item.Value.GetValue());
		}
	}
}
