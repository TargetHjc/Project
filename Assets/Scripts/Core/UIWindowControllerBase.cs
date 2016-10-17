using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// User interface window controller base.
/// </summary>
public class UIWindowControllerBase : MonoBehaviour {

	/// <summary>
	/// The window type array.
	/// </summary>
	public List<UIWindowType> windowTypeArray = new List<UIWindowType>();
	
	/// <summary>
	/// The type of the window container.
	/// </summary>
	public UIWindowContainerType windowContainerType = UIWindowContainerType.Center;
	
	/// <summary>
	/// The type of the window show animation.
	/// </summary>
	public UIWindowShowAnimationType windowShowAnimationType = UIWindowShowAnimationType.Normal;
	
	/// <summary>
	/// The duration.
	/// </summary>
	public float duration = 1f;
	
	/// <summary>
	/// The window user interface show animation curve.
	/// </summary>
	public AnimationCurve windowUIShowAnimationCurve = new AnimationCurve();
	
	/// <summary>
	/// The type of the window.
	/// </summary>
	[HideInInspector]
	public UIWindowType windowType = UIWindowType.Login;

	// Use this for initialization
	void Start()
	{
		UIButton[] btnArray = transform.GetComponentsInChildren<UIButton>();
		foreach (UIButton btn in btnArray)
		{
			UIEventListener.Get(btn.gameObject).onClick = ButtonClick;
		}
		OnStart();
	}
	
	void ButtonClick(GameObject btn)
	{		
		OnButtonClick(btn);
	}	
	
	// Update is called once per frame
	void Update()
	{
		OnUpdate();
	}
	
	void OnDestroy()
	{
		BeforeOnDestroy();		
	}
	
	protected virtual void OnStart() {}
	protected virtual void OnUpdate() {}
	protected virtual void OnButtonClick(GameObject btn) {}
	protected virtual void BeforeOnDestroy() {
		//内存泄漏
		Debug.LogWarning("此处代码有bug 点击注册后，立即结束游戏，即将要打开的窗口不会立即释放");
		foreach (UIWindowType windowType in windowTypeArray)
		{
			UIWindowManager.Instance.OpenUIWindow(windowType);
		}
		windowTypeArray.Clear();
	}
}
