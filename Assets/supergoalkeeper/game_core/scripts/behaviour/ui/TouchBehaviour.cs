using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Touch behaviour class; Not in use, but
/// define a set of operations which
/// all objects that implement class must support 
/// (similar ButtonBehaviour class).
/// </summary>
public class TouchBehaviour : MonoBehaviour {
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	protected virtual void Start () {
		
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	protected virtual void Update () {
		
	}
	
	//MOUSE TRIGGERs
	/// <summary>
	/// Raises the touch began event.
	/// </summary>
	/// <param name="v">V.</param>
	protected virtual void OnTouchBegan(Vector3 v)		{}
	/// <summary>
	/// Raises the touch canceled event.
	/// </summary>
	/// <param name="v">V.</param>
	protected virtual void OnTouchCanceled(Vector3 v)	{}
	/// <summary>
	/// Raises the touch ended event.
	/// </summary>
	/// <param name="v">V.</param>
	protected virtual void OnTouchEnded(Vector3 v)		{}
	/// <summary>
	/// Raises the touch moved event.
	/// </summary>
	/// <param name="v">V.</param>
	protected virtual void OnTouchMoved(Vector3 v)		{}
	/// <summary>
	/// Raises the touch stay event.
	/// </summary>
	/// <param name="v">V.</param>
	protected virtual void OnTouchStay(Vector3 v)		{}
	protected virtual void action()						{}
}
}