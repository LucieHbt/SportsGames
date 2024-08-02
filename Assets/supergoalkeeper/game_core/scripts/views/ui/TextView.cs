using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace game_core
{
/// <summary>
/// Text view class; Abstraction layer to deal with UI elements(Text in this case).
/// </summary>
public class TextView{

	//VARIABLES
	private string 		_GameObjectName 	= 	"Text";
	private bool 		_active				=	false;
	private GameObject	_GameObject;
	private Transform	_bar;
	private Vector3		_barScale;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="TextView"/> class.
	/// </summary>
	public TextView(string name)
	{
		_GameObjectName	=	(name!="")?	name	:	_GameObjectName;
		_GameObject 	= 	GameObject.Find( _GameObjectName);
	}
	
	
	/// <summary>
	/// Games the object.
	/// </summary>
	/// <returns>The object.</returns>
	public GameObject gameObject
	{
		get
		{
			return _GameObject;
		}
	}
	
	/// <summary>
	/// Transform this instance.
	/// </summary>
	public Transform transform
	{
		get
		{
			return _GameObject.transform;
		}
	}	
	
	/// <summary>
	/// Transform this instance.
	/// </summary>
	public RectTransform rectTransform
	{
		get
		{
			if(gameObject==null)	{ return null;}
			return transform.GetComponent<RectTransform>();
		}
	}	
	
	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <value>The position.</value>
	public Vector3 position
	{
		
		get
		{
			return transform.position;
		}
		
	}
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="IndicatorView"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	public bool active
	{
		set{
			_active	=	value;
			if(gameObject!=null)
			{
				gameObject.SetActive(value);
			}
		}
		get{
			return _active;
		}
	}
	
	/// <summary>
	/// Sets the text.
	/// </summary>
	/// <value>The text.</value>
	public string text
	{
		set{
			Text txt	=	transform.GetComponent<Text>();
			if(txt==null)
			{
				txt	=	transform.Find("Text").GetComponent<Text>();
			}
			if(txt!=null)
			{
				txt.text=value;
			}
		}
		
	}
}
}