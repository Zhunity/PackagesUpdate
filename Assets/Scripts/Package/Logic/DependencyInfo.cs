using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyInfo : Class
{
	public Property version;
	public Property nameP;

	public DependencyInfo(Type type) : base(type)
	{
		version = new Property(this, "version");
		this.nameP = new Property(this, "name");
	}
}
