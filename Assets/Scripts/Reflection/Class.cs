using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = System.Object;

public class Class
{
	public string name;			// 名字（在member中相当于变量名）
	public Type type;			// 对象的实际类型
	public Object instance;     // 这个对象的实例
	protected List<Member> memberList = new List<Member>();

	public Object Value
	{
		get
		{
			return GetValue();
		}
	}

	protected Class()
	{
		memberList.Clear();
	}

	public Class(Type type)
	{
		this.type = type;
		name = type.FullName;
		memberList.Clear();
	}

	public virtual Object GetValue()
	{
		return instance;
	}

	public void SetInstance(Object instance)
	{
		if(this.instance == instance)
		{
			return;
		}
		this.instance = instance;

		if (memberList != null && memberList.Count > 0)
		{
			foreach (var member in memberList)
			{
				member.SetBelong(instance);
			}
		}

		OnSetInstance();
	}

	protected virtual void OnSetInstance()
	{

	}

	/// <summary>
	/// 获取对象的模板参数
	/// </summary>
	/// <returns></returns>
	public Type[] GetGenericTypeArguments()
	{
		if(type.IsGenericType)
		{
			return type.GenericTypeArguments;
		}
		return null;
	}

	public object ConvertObject(Type type)
	{
		return Utils.ConvertObject(Value, type);
	}



	protected void SetMemberList(Class belongMember)
	{
		belongMember.memberList.Add(this as Member);
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

	/// <summary>
	/// 显示内部成员的值
	/// </summary>
	protected void ShowMembersValue()
	{
		Object instance = GetValue();
		if (instance == null)
		{
			return;
		}

		Debug.Log("");
		Debug.Log("----------------------------" + name + " begin--------------------------------");
		var list = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach (var item in list)
		{
			if (item.MemberType == MemberTypes.Property)
			{
				PropertyInfo info = item as PropertyInfo;
				object value = info.GetValue(instance);
				Debug.Log("Name:\t\t" + item.Name + "\nvalue:\t" + value + "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
			}
			else if (item.MemberType == MemberTypes.Field)
			{
				FieldInfo info = item as FieldInfo;
				object value = info.GetValue(instance);
				Debug.Log("Name:\t\t" + item.Name + "\nvalue:\t" + value + "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
			}
		}
		Debug.Log("----------------------------" + name + " end--------------------------------");
		Debug.Log("");
	}
}
