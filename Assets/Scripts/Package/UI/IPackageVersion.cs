using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 显示选中package的信息
/// </summary>
public class IPackageVersion : Property
{
	Property displayName;
	Property description;
	static bool show = true;

	public IPackageVersion(Member belongMember, string name) : base(belongMember, name)
	{
	}

	protected override void OnSetBelong()
	{
	}
}
