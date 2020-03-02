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
	Type windowType;
	PackageWindow packageWindow;
	

	void Awake()
    {
		if (DestroyOnPlay())
		{
			return;
		}
		Debug.Log("EditorAwake");
		windowType = Utils.GetType(packageManagerWidowName);
		packageWindow = new PackageWindow(windowType);


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
			packageWindow.SetInstance(window);
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
}
