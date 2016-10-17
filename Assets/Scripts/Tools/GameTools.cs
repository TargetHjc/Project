using UnityEngine;
using System.Collections;

/// <summary>
/// Game tools.
/// </summary>
public static class GameTools{
	
	/// <summary>
	/// Gets the or add component.
	/// </summary>
	/// <returns>The or add component.</returns>
	/// <param name="go">Go.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T GetOrAddComponent<T>(this GameObject go) where T:Behaviour
	{
		T t = go.GetComponent<T>();
		if (t == null)
			t = go.AddComponent<T>();
		return t;
	}
}
