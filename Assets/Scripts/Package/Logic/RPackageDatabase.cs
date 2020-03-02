using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPackageDatabase : Class
{
	Property s_instance;
	PackageDatabaseInternal instanceInternal;



	public RPackageDatabase(Type type) : base(type)
	{
		ShowMembers();
		s_instance = new Property(this, "instance");
		SetInstance(s_instance.GetValue());

		
		Debug.Log(s_instance.GetValue().GetType());
	}

	public class PackageDatabaseInternal : Class
	{

	}
}
