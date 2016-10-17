using UnityEngine;
using System.Collections;

/// <summary>
/// User interface scene controller base.
/// </summary>
public class UISceneControllerBase : MonoBehaviour {

	/// <summary>
	/// The center container.
	/// </summary>
	public Transform centerContainer;
	/// <summary>
	/// The left top container.
	/// </summary>
	public Transform leftTopContainer;
	/// <summary>
	/// The left bottom container.
	/// </summary>
	public Transform leftBottomContainer;
	/// <summary>
	/// The right top container.
	/// </summary>
	public Transform rightTopContainer;
	/// <summary>
	/// The right center container.
	/// </summary>
	public Transform rightCenterContainer;
	/// <summary>
	/// The right bottom container.
	/// </summary>
	public Transform rightBottomContainer;

	// Use this for initialization
	void Start () {
		OnStart();
	}
	
	// Update is called once per frame
	void Update () {
		OnUpdate();
	}

	protected virtual void OnStart() {}
	protected virtual void OnUpdate() {}
}
