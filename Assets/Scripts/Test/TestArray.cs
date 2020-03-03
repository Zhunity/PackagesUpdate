using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray  : MonoBehaviour
{
	private void Awake()
	{
		ReflectionVisualElement();



	}

	private void ReflectionVisualElement()
	{
		UnityEngine.UIElements.VisualElement a = new UnityEngine.UIElements.VisualElement();
		Class visualElement = new Class(typeof(UnityEngine.UIElements.VisualElement));
		Property Array = new Property(visualElement, "Item");
		visualElement.SetInstance(a);
		Debug.Log(Array.propertyInfo.GetValue(a));
	}

	private void ReflectionMyArray()
	{
		MyArray array = new MyArray();

		int[] a = new int[1];

		Class rArray = new Class(typeof(MyArray));
		Property Array = new Property(rArray, "Array");
		rArray.SetInstance(array);
		Debug.Log(Array.propertyInfo);
		Debug.Log(new int[10]);
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
