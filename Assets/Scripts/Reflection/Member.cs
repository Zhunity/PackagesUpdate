using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

/// <summary>
/// 一个对象里面的成员
/// 如果一种类型既有在Property成员，也有Field类型，建议使用Member
/// TODO 适配上面这种情况
/// </summary>
public class Member
{
	public string name;
	public MemberInfo memberInfo;
	public Type type;	// 这个成员的类型

	public Object belong;

	public Member()
	{

	}

	public Member(Type belongType, string name)
	{
		memberInfo = belongType.GetMember(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First();
		if(memberInfo == null)
		{
			Debug.LogError("can not find " + name + " in " + belongType);
			return;
		}
		this.name = name;

		// 这么取是不对的。。。
		// TODO memberInfo怎么取到
		type = memberInfo.ReflectedType;
	}

	public void SetBelong(Object belong)
	{
		this.belong = belong;
		OnSetBelong();
	}

	public void SetBelong(Member belong)
	{
		var obj = belong.GetValue();
		this.belong = obj;
		OnSetBelong();
	}

	public virtual Object GetValue()
	{
		return null;
	}

	protected virtual void OnSetBelong()
	{

	}

	/// <summary>
	/// Name:变量名
	/// ReflectedType：当前变量所在的变量
	/// MemberType：Property, Field等类型
	/// DeclaringType：定义这个变量的类型位置
	/// </summary>
	protected void ShowMembers()
	{
		var list = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach (var item in list)
		{
			Debug.Log("Name:\t\t" + item.Name + "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
		}
	}
}
