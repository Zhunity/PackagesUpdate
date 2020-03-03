using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray  : MonoBehaviour
{
	private void Awake()
	{
		MyArray array = new MyArray();

		int[] a = new int[1];

		Class rArray = new Class(typeof(MyArray));
		Property Array = new Property(rArray, "Array");
		rArray.SetInstance(array);
		Debug.Log(Array.propertyInfo);

		rArray.ShowMembersValue();
	}
}

public class MyArray
{
	public int[] array = new int[] { 1, 2, 3 };

	public ArrayProperty[] Array
	{
		get
		{
			return new ArrayProperty[2];
		}
	}
}

public class ArrayProperty
{

}
