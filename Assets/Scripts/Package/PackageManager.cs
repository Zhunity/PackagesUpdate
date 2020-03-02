using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager;
using System;
using System.Reflection;
using UnityEditor;
using Object = UnityEngine.Object;
using System.Linq;

[ExecuteInEditMode]
public class PackageManager : MonoBehaviour
{
	string packageManagerWidowName = "PackageManagerWindow";
	const string packageDetailsName = "packageDetails";
	Type windowType;

	PackageDetails packageDetails;

	void Awake()
    {
		if (DestroyOnPlay())
		{
			return;
		}
		Debug.Log("EditorAwake");
		windowType = GetType(packageManagerWidowName);
		packageDetails = new PackageDetails(windowType, packageDetailsName);
		EditorApplication.update += EditorUpdate;
	}

	private void EditorUpdate()
	{
		if (DestroyOnPlay())
		{
			return;
		}
		var window = Resources.FindObjectsOfTypeAll(windowType).FirstOrDefault();
		if (window != null)
		{
			packageDetails.SetWindow(window);
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
