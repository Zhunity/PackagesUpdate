using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class Event : Member
{
	EventInfo fieldInfo;

	public Event(Class belongMember, string name) : base(belongMember, name)
	{
	}

	public Event(Type belongType, string name) : base(belongType, name)
	{
	}
}
