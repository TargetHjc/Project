using UnityEngine;
using System.Collections;

/// <summary>
/// User interface scene manager.
/// </summary>
public class UISceneManager : SingleTon<UISceneManager> {

	/// <summary>
	/// The current user interface scene controller.
	/// </summary>
	public UISceneControllerBase currentUISceneController;

	/// <summary>
	/// Opens the user interface scene.
	/// </summary>
	/// <param name="sceneType">Scene type.</param>
	public void OpenUIScene(UISceneType sceneType){
		GameObject sceneUI = null;
		switch (sceneType) { 
		case UISceneType.Login:
			sceneUI = ResourceManager.Instance.Load("UI Root_LoginScene",resType: ResourceType.UIScene);
			break;
		case UISceneType.Loading:
			sceneUI = ResourceManager.Instance.Load("UI Root_LoadingScene",resType: ResourceType.UIScene);
			break;
		case UISceneType.Battle:
			sceneUI = ResourceManager.Instance.Load("UI Root_BattleScene",resType: ResourceType.UIScene);
			break;
		default:
			break;
		}
		currentUISceneController = sceneUI.GetComponent<UISceneControllerBase>();
	}
}
