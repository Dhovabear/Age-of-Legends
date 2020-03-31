using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;

class CreatePrefabFromSelected : ScriptableObject
{
	const string menuTitle = "GameObject/Create Prefab From Selected";
	
	/// <summary>
	/// Creates a prefab from the selected game object.
	/// </summary>
	[MenuItem(menuTitle)]
	static void CreatePrefab()
	{
		var objs = Selection.gameObjects;
		
		string pathBase = EditorUtility.SaveFolderPanel ("Choose save folder", "Assets", "");
		
		if (!String.IsNullOrEmpty (pathBase)) {
			
			pathBase=pathBase.Remove(0,pathBase.IndexOf("Assets"))+Path.DirectorySeparatorChar;
			
			foreach (var go in objs) {
				String localPath = pathBase + go.name + ".prefab";
				
				if (AssetDatabase.LoadAssetAtPath (localPath, typeof(GameObject))) {
					if (EditorUtility.DisplayDialog ("Are you sure?", 
					                                 "The prefab already exists. Do you want to overwrite it?", 
					                                 "Yes", 
					                                 "No"))
						createNew (go, localPath);
				} else
					createNew (go, localPath);
			}
		}
	}
	
	static void createNew(GameObject obj, string localPath)
	{
		var prefab = PrefabUtility.CreatePrefab (localPath, obj);
		EditorUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
		AssetDatabase.Refresh();
	}
	
	/// <summary>
	/// Validates the menu.
	/// </summary>
	/// <remarks>The item will be disabled if no game object is selected.</remarks>
	[MenuItem(menuTitle, true)]
	static bool ValidateCreatePrefab()
	{
		return Selection.activeGameObject != null;
	}
}