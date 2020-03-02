using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class Utils 
{
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
