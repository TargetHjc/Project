/// <summary>
/// Singleton.
/// </summary>
public class SingleTon<T> where T : new() {

	/// <summary>
	/// The instance.
	/// </summary>
	private static T instance;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static T Instance{
		get{
			if (instance == null)
				instance = new T();
			return instance;
		}
	}
}
