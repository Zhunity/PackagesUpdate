using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageList : Member
{
	Field m_PackageItemsLookup;

	public PackageList(Member belongMember, string name) : base(belongMember, name)
	{
		m_PackageItemsLookup = new Field(this, "m_PackageItemsLookup");
	}

	protected override void OnSetBelong()
	{
		Debug.Log(m_PackageItemsLookup.Value);
	}
}
