using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Button behaviour.
/// </summary>
public class ButtonBehaviour : MonoBehaviour {

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	protected virtual void Start () {
	
	}

	/// <summary>
	/// Fixed Update is called every fixed framerate frame.
	/// </summary>
	protected virtual void FixedUpdate(){
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	protected virtual void Update () {
	
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	protected virtual void OnEnable(){

	}
	/// <summary>
	/// Raises the click event event.
	/// </summary>
	public virtual void OnClickEvent(){action ();}

	//MOUSE TRIGGERs
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	protected virtual void OnMouseDown()	{action ();}
	/// <summary>
	/// Raises the mouse drag event.
	/// </summary>
	protected virtual void OnMouseDrag()	{}
	/// <summary>
	/// Raises the mouse enter event.
	/// </summary>
	protected virtual void OnMouseEnter()	{}
	/// <summary>
	/// Raises the mouse exit event.
	/// </summary>
	protected virtual void OnMouseExit()	{}
	/// <summary>
	/// Raises the mouse over event.
	/// </summary>
	protected virtual void OnMouseOver()	{}
	/// <summary>
	/// Raises the mouse up event.
	/// </summary>
	protected virtual void OnMouseUp()		{}
	protected virtual void action()			{}
}
}