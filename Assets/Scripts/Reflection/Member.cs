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
/// NOTODO 逐层递增，用到的时候自己解析？ 用起来看起来很方便，但是感觉可能调试不好搞，还是不要这么搞了
/// </summary>
public class Member : Class
{
	public string name;
	public MemberInfo memberInfo;

	public Type belongType;
	public Object belong;

	

	public Object Value
	{
		get
		{
			return GetValue();
		}
	}

	#region 初始化类型数据
	// 这个是定义类型用的
	public Member(Type type)
	{
		this.type = type;
	}

	// 这个是递归引用时用的
	public Member(Member belongMember, string name) : this(belongMember.type, name)
	{
		Debug.Log(belongMember + " " + name);
		SetBelongCallback(belongMember);
	}

	// 这个是根节点用的
	// 只用一个类型内的某个参数，不需要定义一个类型
	public Member(Type belongType, string name)
	{
		SetInfo(belongType, name);
		SetBelongType(belongType);
		SetName(name);
		SetType();
	}

	/// <summary>
	/// 设置变量成员信息
	/// </summary>
	/// <param name="belongType"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	protected virtual void SetInfo(Type belongType, string name)
	{
		memberInfo = belongType.GetMember(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First();
	}

	/// <summary>
	/// 设置变量名
	/// 操作简单，目测不用重写
	/// </summary>
	/// <param name="name"></param>
	protected void SetName(string name)
	{
		this.name = name;
	}
	
	/// <summary>
	/// 设置所属对象类型
	/// </summary>
	/// <param name="belongType"></param>
	protected void SetBelongType(Type belongType)
	{
		this.belongType = belongType;
	}

	/// <summary>
	/// Member这么取是不对的。。。
	/// TODO memberInfo怎么取到
	/// </summary>
	protected virtual void SetType()
	{
		if (memberInfo == null)
		{
			Debug.LogError("can not find " + name + " in " + belongType);
		}
		type = memberInfo.ReflectedType;
	}

	protected void SetBelongCallback(Member belongMember)
	{
		belongMember.memberList.Add(this);
	}
	#endregion

	#region 设置持有该成员的对象
	/// <summary>
	/// 设置持有该成员的对象
	/// </summary>
	/// <param name="belong"></param>
	public void SetBelong(Object belong)
	{
		if(this.belong == belong)
		{
			Debug.Log("--------");
			return;
		}
		Debug.LogError("||||||||||||||||||||");
		this.belong = belong;

		if (memberList != null && memberList.Count > 0)
		{
			foreach (var member in memberList)
			{
				member.SetBelong(this);
			}
		}

		OnSetBelong();
	}

	public void SetBelong(Member belong)
	{
		var obj = belong.GetValue();
		SetBelong(obj);
	}

	protected virtual void OnSetBelong()
	{

	}
	#endregion

	/// <summary>
	/// 相对于一个类来说，设置该类的持有对象，相当于设置该类的实例对象
	/// </summary>
	/// <param name="instance"></param>
	public void SetInstance(object instance)
	{
		SetBelong(instance);
	}

	public virtual Object GetValue()
	{
		return null;
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
		if(instance == null)
		{
			return;
		}

		Debug.Log("");
		Debug.Log("----------------------------" + name + " begin--------------------------------");
		var list = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach (var item in list)
		{
			if(item.MemberType == MemberTypes.Property)
			{
				PropertyInfo info = item as PropertyInfo;
				object value = info.GetValue(instance);
				Debug.Log("Name:\t\t" + item.Name + "\nvalue:\t" + value +  "\nReflectedType:\t" + item.ReflectedType + "\nMemberType:\t" + item.MemberType + "\nDeclaringType:\t" + item.DeclaringType);
			}
			else if(item.MemberType == MemberTypes.Field)
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
