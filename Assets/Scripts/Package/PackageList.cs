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
	Dictionary<string, RPackageItem> r_PackageItemsLookup = new Dictionary<string, RPackageItem>();

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
		Debug.Log(dict.Count);
		while(iter.MoveNext())
		{
			Debug.Log(iter.Key + "  " + iter.Value);
			RPackageItem item = new RPackageItem(packageItemType);
			item.SetInstance(iter.Value);
			r_PackageItemsLookup.Add(iter.Key.ToString(), item);
		}
		Debug.Log(r_PackageItemsLookup.Count);
	}
}
