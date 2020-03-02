using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Class
{
	public Type type;			// 对象的实际类型
	public Object instance;     // 这个对象的实例
	private List<Member> memberList = new List<Member>();

	public Class(Type type)
	{
		this.type = type;
	}
}
