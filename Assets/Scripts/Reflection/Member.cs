using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// 一个对象里面的成员
/// </summary>
public class Member
{
	string name;
	MemberInfo memberInfo;
	Type ReflectedType;

	Object belong;


	public Member(Type belongType, string name)
	{
		memberInfo = belongType.GetMember(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First();
		if(memberInfo == null)
		{
			Debug.LogError("can not find " + name + " in " + belongType);
			return;
		}
		ReflectedType = memberInfo.ReflectedType;
		ShowMembers();
	}

	public void SetBelong(Object belong)
	{
		this.belong = belong;
	}

	private void ShowMembers()
	{
		var list = ReflectedType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach (var item in list)
		{
			Debug.Log("Name:\t\t" + item.Name + "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
		}
	}
}
