using UnityEngine;
using System.Collections;
using System.Text;

/// <summary>
/// Resource manager.
/// </summary>
public class ResourceManager : SingleTon<ResourceManager> {

	/// <summary>
	/// Load the specified path and resType.
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="resType">Res type.</param>
	public GameObject Load(string path,ResourceType resType = ResourceType.UIScene)
	{
		//string StringBuilder区别：string是固定字符的字符串，StringBuilder不是
		StringBuilder src = new StringBuilder();
		switch (resType)
		{
		case ResourceType.UIScene:
			src.Append("UI/UIScene/");
			break;
		case ResourceType.UIWindow:
			src.Append("UI/UIWindow/");
			break;
		case ResourceType.Character:
			src.Append("Character/");
			break;
		case ResourceType.Camera:
			src.Append("Camera/");
			break;
		default:
			break;
		}
		src.Append(path);
		GameObject uiRes = Resources.Load(src.ToString()) as GameObject;
		return GameObject.Instantiate(uiRes);
	}
}
