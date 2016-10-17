using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// User interface window manager.
/// </summary>
public class UIWindowManager : SingleTon<UIWindowManager> {

	/// <summary>
	/// The user interface window dic.
	/// </summary>
	private Dictionary<UIWindowType, GameObject> uiWindowDic = new Dictionary<UIWindowType, GameObject>();

	/// <summary>
	/// Opens the user interface window.
	/// </summary>
	/// <param name="windowType">Window type.</param>
	public void OpenUIWindow(UIWindowType windowType)
	{
		if (uiWindowDic.ContainsKey(windowType)) return;
		GameObject uiWindow = null;
		switch (windowType) { 
		case UIWindowType.Login:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Login", resType: ResourceType.UIWindow);
			break;
		case UIWindowType.Register:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Register", resType: ResourceType.UIWindow);
			break;
		case UIWindowType.Header:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Header", resType: ResourceType.UIWindow);
			break;
		case UIWindowType.Function:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Function", resType: ResourceType.UIWindow);
			break;
		case UIWindowType.Skill:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Skill", resType: ResourceType.UIWindow);
			break;
		case UIWindowType.Progress:
			uiWindow = ResourceManager.Instance.Load("UIWindow_Progress", resType: ResourceType.UIWindow);
			break;
		default:
			break;
		}

		UIWindowControllerBase uiWindowController = uiWindow.GetOrAddComponent<UIWindowControllerBase>();
		uiWindowController.windowType = windowType;
		
		Transform transParentWindowContainer = null;
		
		UIWindowContainerType windowContainerType = uiWindowController.windowContainerType;
		switch (windowContainerType)
		{
		case UIWindowContainerType.Center:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.centerContainer;
			break;
		case UIWindowContainerType.LeftBottom:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.leftBottomContainer;
			break;
		case UIWindowContainerType.LeftTop:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.leftTopContainer;
			break;
		case UIWindowContainerType.RightBottom:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.rightBottomContainer;
			break;
		case UIWindowContainerType.RightTop:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.rightTopContainer;
			break;
		case UIWindowContainerType.RightCenter:
			transParentWindowContainer = UISceneManager.Instance.currentUISceneController.rightCenterContainer;
			break;
		default:
			break;
		}
		uiWindow.transform.parent = transParentWindowContainer;
		uiWindow.transform.localPosition = Vector3.zero;
		uiWindow.transform.localScale = Vector3.one;
		
		uiWindowDic.Add(windowType, uiWindow);		

		NGUITools.SetActive(uiWindow, false);
		UIWindowShowAnimationType windowShowAnimationType = uiWindowController.windowShowAnimationType;
		StartActiveUIWindow(uiWindow, windowShowAnimationType: windowShowAnimationType, state: true);
	}

	/// <summary>
	/// Closes the user interface window.
	/// </summary>
	/// <param name="windowType">Window type.</param>
	public void CloseUIWindow(UIWindowType windowType)
	{
		if(uiWindowDic.ContainsKey(windowType)){
			GameObject uiWindow = uiWindowDic[windowType];
			UIWindowControllerBase uiWindownController = uiWindow.GetOrAddComponent<UIWindowControllerBase>();
			UIWindowShowAnimationType windowShowAnimationType = uiWindownController.windowShowAnimationType;
			StartActiveUIWindow(uiWindow,windowShowAnimationType, state: false);
		}
	}

	/// <summary>
	/// Starts the active user interface window.
	/// </summary>
	/// <param name="uiWindow">User interface window.</param>
	/// <param name="windowShowAnimationType">Window show animation type.</param>
	/// <param name="state">If set to <c>true</c> state.</param>
	public void StartActiveUIWindow(GameObject uiWindow, UIWindowShowAnimationType windowShowAnimationType = UIWindowShowAnimationType.CenterToBig, bool state = true)
	{
		switch (windowShowAnimationType)
		{
		case UIWindowShowAnimationType.Normal:
			ShowNormal(uiWindow, state);
			break;
		case UIWindowShowAnimationType.CenterToBig:
			ShowCenterToBig(uiWindow, state);
			break;
		case UIWindowShowAnimationType.LeftToCenter:
			ShowDirection(uiWindow,state,1);
			break;
		case UIWindowShowAnimationType.RightToCenter:
			ShowDirection(uiWindow, state, 2);
			break;
		case UIWindowShowAnimationType.TopToCenter:
			ShowDirection(uiWindow, state, 3);
			break;
		case UIWindowShowAnimationType.BottomToCenter:
			ShowDirection(uiWindow, state, 4);
			break;
		default:
			break;
		}		
	}
	
	/// <summary>
	/// Shows the center to big.
	/// </summary>
	/// <param name="uiWindow">User interface window.</param>
	/// <param name="state">If set to <c>true</c> state.</param>
	private void ShowCenterToBig(GameObject uiWindow,bool state)
	{		
		TweenScale ts = uiWindow.GetOrAddComponent<TweenScale>();
		
		ts.from = Vector3.zero;
		ts.to = Vector3.one;
		
		UIWindowControllerBase uiWindowController = uiWindow.GetOrAddComponent<UIWindowControllerBase>();
		ts.duration = uiWindowController.duration;
		ts.animationCurve = uiWindowController.windowUIShowAnimationCurve;
		
		if (state)
			NGUITools.SetActive(uiWindow, true);
		if (!state)
		{
			//lambda expression
			ts.SetOnFinished(() => {
				DestroyUIWindow(uiWindow);
			});
			ts.Play(false);
		}
	}

	/// <summary>
	/// Shows the normal.
	/// </summary>
	/// <param name="uiWindow">User interface window.</param>
	/// <param name="state">If set to <c>true</c> state.</param>
	private void ShowNormal(GameObject uiWindow,bool state)
	{
		if (state)
			NGUITools.SetActive(uiWindow, true);
		else
			DestroyUIWindow(uiWindow);		
	}

	/// <summary>
	/// Shows the direction.
	/// </summary>
	/// <param name="uiWindow">User interface window.</param>
	/// <param name="state">If set to <c>true</c> state.</param>
	/// <param name="direct">Direct.</param>
	private void ShowDirection(GameObject uiWindow,bool state,int direct)
	{
		Vector3 from = Vector3.zero;
		Vector3 to = Vector3.zero;
		switch (direct)
		{
		case 1:
			from = Vector3.left * Screen.width;
			break;
		case 2:
			from = Vector3.right * Screen.width;
			break;
		case 3:
			from = Vector3.up * Screen.height;
			break;
		case 4:
			from = Vector3.down * Screen.height;
			break;
		default:
			Debug.LogError("Your parm is ERROR!Please use 1/2/3/ or 4");
			break;
		}
		
		TweenPosition tp = uiWindow.GetOrAddComponent<TweenPosition>();
		tp.from = from;
		tp.to = to;
		
		UIWindowControllerBase uiWindowController = uiWindow.GetOrAddComponent<UIWindowControllerBase>();
		tp.duration = uiWindowController.duration;
		tp.animationCurve = uiWindowController.windowUIShowAnimationCurve;
		
		if (state)
			NGUITools.SetActive(uiWindow, true);
		if (!state)
		{
			tp.SetOnFinished(() => {
				DestroyUIWindow(uiWindow);
			});
			tp.Play(false);			
		}		
	}

	/// <summary>
	/// Destroies the user interface window.
	/// </summary>
	/// <param name="uiWindow">User interface window.</param>
	private void DestroyUIWindow(GameObject uiWindow)
	{
		UIWindowControllerBase uiWindowController = uiWindow.GetOrAddComponent<UIWindowControllerBase>();
		if (uiWindowDic.ContainsKey(uiWindowController.windowType))
			uiWindowDic.Remove(uiWindowController.windowType);
		GameObject.Destroy(uiWindow);
	}
}
