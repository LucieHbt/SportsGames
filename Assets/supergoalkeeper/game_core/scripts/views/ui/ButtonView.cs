using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace game_core
{
	
	/// <summary>
	/// Button view class; Abstraction layer to deal with UI elements(Buttons in this case).
	/// </summary>
	public class ButtonView{
		
		//VARIABLES
		private string 		_GameObjectName 	= 	"button";
		private bool 		_active				=	false;
		private bool		_interactable 		=	false;
		private GameObject	_GameObject;
		private Button		_button;
		/// <summary>
		/// Initializes a new instance of the <see cref="BarView"/> class.
		/// </summary>
		public ButtonView(string name)
		{
			_GameObjectName	=	(name!="")?	name	:	_GameObjectName;
			_GameObject 	= 	GameObject.Find( _GameObjectName);
			if(_GameObject!=null)
			{
				_button = transform.GetComponent<Button>();
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
		public bool interactable
		{
			set{
				_interactable =	value;
				if(_button!=null)
				{
					_button.interactable=value;
				}
			}
			get{
				return _interactable;
			}
		}
		
	}
}