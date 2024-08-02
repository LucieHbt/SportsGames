using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace game_core
{

/// <summary>
/// Bar view class; Abstraction layer to deal with UI elements(Bar in this case).
/// </summary>
public class BarView{

	//VARIABLES
	private string 		_GameObjectName 	= 	"healthBar";
	private bool 		_active				=	false;
	private GameObject	_GameObject;
	private Transform	_bar;
	private Vector3		_barScale;

	/// <summary>
	/// Initializes a new instance of the <see cref="BarView"/> class.
	/// </summary>
	public BarView(string name)
	{
		_GameObjectName	=	(name!="")?	name	:	_GameObjectName;
		_GameObject 	= 	GameObject.Find( _GameObjectName);
		
		if ( _GameObject != null )
		{
			_bar 			= transform.Find ("bar");
			_barScale 		= _bar.GetComponent<RectTransform>().localScale;
		}
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
			if(txt!=null)
			{
				txt.text=value;
			}
		}
		
	}

	/// <summary>
	/// Sets the value.
	/// </summary>
	/// <value>The value.</value>
	public float value
	{
		set{
			if(_bar!=null)
			{
				_bar.GetComponent<RectTransform>().localScale = new Vector3(_barScale.x * value * 0.01f, 1, 1);
				text 		= (value*0.01f).ToString ("0%");
			}
		}
	}
	
}
}
