using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Manifest
{
	private static string LoadTextInEditor(string assetPath)
	{
		try
		{
			return File.ReadAllText(assetPath);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void LoadManifest(string path)
	{
		var text = LoadTextInEditor(path);
		if (string.IsNullOrEmpty(text)) return;
		var config = MiniJSON.Json.Deserialize(text) as Dictionary<string, object>;
		foreach (var item in config)
		{
			foreach(var info in item.Value as Dictionary<string, object>)
			{
					Debug.Log(info.Key + "  " + info.Value);
			}
		}
	}
}
