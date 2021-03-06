﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;


public class Field : Member
{
	FieldInfo fieldInfo;

	public Field(Class belongMember, string name) : base(belongMember, name)
	{
	}

	public Field(Type belongType, string name) : base(belongType, name)
	{
	}

	public static object GetFieldValue(FieldInfo info, object belong)
	{
		// 判断静态类型
		if (belong == null && !info.IsStatic)
		{
			return null;
		}

		return info.GetValue(belong);
	}

	public override void SetValue(object value)
	{
		fieldInfo.SetValue(belong, value);
	}

	public override object GetValue()
	{
		return GetFieldValue(fieldInfo, belong);
	}

	protected override void SetInfo(Type belongType, string name)
	{
		fieldInfo = belongType.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
	}

	protected override void SetType()
	{
		if (fieldInfo == null)
		{
			Debug.LogError("can not find " + name);
			return;
		}
		type = fieldInfo.FieldType;
	}
}
