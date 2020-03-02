using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPackageVersion : Property
{
	Property displayName;
	Property description;
	static bool show = true;

	public IPackageVersion(Member belongMember, string name) : base(belongMember, name)
	{
		ShowMembers();
	}

	protected override void OnSetBelong()
	{
		//if(show)
		{
			ShowMembersValue();
			show = false;
		}
		
	}
}
