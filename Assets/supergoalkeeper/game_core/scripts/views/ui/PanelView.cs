using UnityEngine;
using System.Collections;
namespace game_core
{
/// <summary>
/// Panel view class; Abstraction layer to deal with UI elements(Panel in this case).
/// </summary>
public class PanelView{

	//VARIABLES
	private string 		_GameObjectName 	= 	"PanelMenu";
	private bool 		_active				=	false;
	private GameObject	_GameObject;

	/// <summary>
	/// Initializes a new instance of the <see cref="PanelView"/> class.
	/// </summary>
	public PanelView(string name)
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
			if(_GameObject==null)	{ return null;}
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
			//return gameObject.GetComponent( typeof( RectTransform )) as RectTransform;
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

	}
}
