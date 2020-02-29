using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager;
using System;
using System.Reflection;
using UnityEditor;

[ExecuteInEditMode]
public class PackageManager : MonoBehaviour
{
	Type window = GetType("PackageManagerWindow");

	

	void Awake()
    {
		if (DestroyOnPlay())
		{
			return;
		}
		Debug.Log("EditorAwake");
		var list = window.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
		foreach(var item in list)
		//if(item!= null)
		{
			Debug.Log(item.Name + "  " + item.MemberType + "  " + item.DeclaringType);
		}

		//EditorApplication.update += EditorUpdate;
	}

	private void EditorUpdate()
	{
		if (DestroyOnPlay())
		{
			return;
		}
		var windows = Resources.FindObjectsOfTypeAll(window);
		if (windows != null && windows.Length > 0)
		{
			foreach (var item in windows)
			{
				
			}
		}
	}

	private bool DestroyOnPlay()
	{
		if (Application.isPlaying)
		{
			DestroyImmediate(gameObject);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 获取类型
	/// </summary>
	/// <param name="typeName"></param>
	/// <returns></returns>
	public static Type GetType(string typeName)
	{
		Type type = null;
		Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
		int assemblyArrayLength = assemblyArray.Length;
		for (int i = 0; i < assemblyArrayLength; ++i)
		{
			type = assemblyArray[i].GetType(typeName);
			if (type != null)
			{
				return type;
			}
		}

		for (int i = 0; (i < assemblyArrayLength); ++i)
		{
			Type[] typeArray = assemblyArray[i].GetTypes();
			int typeArrayLength = typeArray.Length;
			for (int j = 0; j < typeArrayLength; ++j)
			{
				if (typeArray[j].Name.Equals(typeName))
				{
					return typeArray[j];
				}
			}
		}
		return type;
	}
}
