/// <summary>
/// User interface window type.
/// </summary>
public enum UIWindowType
{
	Login,
	Register,
	Header,
	Function,
	Skill,
	Progress
}

/// <summary>
/// User interface window container type.
/// </summary>
public enum UIWindowContainerType
{
	Center,
	LeftTop,
	LeftBottom,
	RightTop,
	RightCenter,
	RightBottom
}

/// <summary>
/// User interface window show animation type.
/// </summary>
public enum UIWindowShowAnimationType 
{ 
	Normal,
	CenterToBig,
	LeftToCenter,
	RightToCenter,
	TopToCenter,
	BottomToCenter
}

/// <summary>
/// User interface scene type.
/// </summary>
public enum UISceneType
{
	Login,
	Loading,
	Battle	
}

/// <summary>
/// Resource type.
/// </summary>
public enum ResourceType
{
	UIScene = 0,
	UIWindow,
	Character,
	Camera
}
