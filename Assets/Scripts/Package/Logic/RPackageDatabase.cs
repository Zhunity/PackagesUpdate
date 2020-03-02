using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPackageDatabase : Class
{
	Property s_instance;

	public RPackageDatabase(Type type) : base(type)
	{
		//ShowMembers();
		s_instance = new Property(this, "instance");
		Debug.Log(s_instance.GetValue());
	}
}
