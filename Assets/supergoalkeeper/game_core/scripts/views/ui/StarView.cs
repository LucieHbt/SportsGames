using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace game_core
{
	
	/// <summary>
	/// Star view class; Abstraction layer to deal with UI elements(Star in this case).
	/// </summary>
	public class StarView{
		
		//VARIABLES
		private string 		_GameObjectName 	= 	"star_1";
		private bool 		_active				=	false;
		private bool		_activeStar 		= false;
		private GameObject	_GameObject;
		private GameObject	_star;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BarView"/> class.
		/// </summary>
		public StarView(string name)
		{
			_GameObjectName	=	(name!="")?	name	:	_GameObjectName;
			_GameObject 	= 	GameObject.Find( _GameObjectName);
			
			if ( _GameObject != null )
			{
				Transform tmp	=	transform.Find("star");
				if(tmp!=null)
				{
					_star		=	tmp.gameObject;
					activeStar	=	_activeStar;
				}
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
		/// Gets or sets a value indicating whether this <see cref="IndicatorView"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool activeStar
		{
			set{
				_activeStar=value;
				if(_star!=null)
				{
					_star.SetActive(_activeStar);
				}
			}
			get{
				return _activeStar;
			}
		}
		
	}
}