using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TestArray  : MonoBehaviour
{
	private void Awake()
	{
		//ReflectionVisualElement();

		ReflectionMyArray(); 
		
		//ReflectionString();
	}

	private void ReflectionVisualElement()
	{
		UnityEngine.UIElements.VisualElement a = new UnityEngine.UIElements.VisualElement();
		Class visualElement = new Class(typeof(UnityEngine.UIElements.VisualElement));
		Property Array = new Property(visualElement, "Item");
		visualElement.SetInstance(a);
		Debug.Log(Array.propertyInfo);
		Debug.Log(Array.propertyInfo.GetValue(a, new object []{ 0 }));

		//Class proerty = new Class(typeof(PropertyInfo));
		//proerty.SetInstance(Array.propertyInfo);
		//proerty.ShowMembersValue();
	}

	private void ReflectionMyArray()
	{
		MyArray array = new MyArray();

		int[] a = new int[1];

		Class rArray = new Class(typeof(MyArray));
	//	rArray.ShowMembers();
		Property Item = new Property(rArray, "Item");
		rArray.SetInstance(array);
		var method = Item.GetValue() as UniversalFunc;
		//Debug.Log(method(2)  + " ----------- " + Item.GetValue());
		rArray.ShowMembersValue();
	}

	private void ReflectionString()
	{
		PropertyInfo len = typeof(string).GetProperty("Length");
		string s = "Hello,reflection!";
		Debug.Log((int)len.GetValue(s));
	}
}

public class MyArray
{
	public int[] array = new int[] { 1, 2, 3 };

	/// <summary>
	/// 1、不是数组属性
	/// </summary>
	public ArrayProperty[] Array
	{
		get
		{
			return new ArrayProperty[2];
		}
	}

	public ArrayProperty[] item
	{
		get;set;
	}

	// 这样不能重写属性的get
	public ArrayProperty get_item(int index)
	{
		return Array[index];
	}

	/// <summary>
	/// 当属性是索引器的时候，会抛出TargetParameterCountException: Number of parameters specified does not match the expected number.异常
	/// https://www.cnblogs.com/jeffwongishandsome/archive/2009/05/04/1448079.html
	/// 
	/// </summary>
	/// <param name="i"></param>
	/// <returns></returns>
	public int this[int i]
	{
		get
		{
			return array[i];
		}
		set { array[i] = value; }
	}

	// Field
	public Action hello;

	// Property
	public Action search
	{
		get;set;
	}

	// Event
	public event Action selectionChanged;

	// Event
	public event Action close
	{
		add{ }
		remove { }
	}

}

public class ArrayProperty
{

}
