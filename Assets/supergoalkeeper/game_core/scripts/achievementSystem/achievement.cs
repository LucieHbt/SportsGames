using UnityEngine;
using System.Collections;
namespace achievement_system{

	/// <summary>
	/// This class represents the achievement in the Achievement System.
	/// Each achievement has a filter to verify the game progress. The filter 
	/// can be checked every frame to execute an action when achievement
 	/// is accomplished. 
	/// </summary>
	public class achievement : MonoBehaviour {

		public float 		weight				=	1000.0f;
		public bool			checkEveryFrame 	= 	false;
		private Filter		_filter;
		private Transform 	_action;

		/// <summary>
		/// Use this for initialization.
		/// </summary>
		public void Awake()
		{
			_action	=	transform.Find ("action");
			if (_action != null) {
				_action.gameObject.SetActive(false);
			}
		}

		/// <summary>
		/// Use this for initialization.
		/// </summary>
		public void Start () {}


		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void FixedUpdate () 
		{
			if (_action != null && _filter!=null && checkEveryFrame) 
			{
				_action.gameObject.SetActive (_filter.test ());
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="game_core.achievement"/> is accomplished.
		/// </summary>
		/// <value><c>true</c> if is accomplished; otherwise, <c>false</c>.</value>
		public bool isAccomplished
		{
			get{
				if(_filter!=null)
				{
					return _filter.test();
				}
				return false;
			}
		}

		/// <summary>
		/// Gets or sets the filter.
		/// </summary>
		/// <value>The filter.</value>
		public Filter filter
		{
			get{	return _filter;		}
			set{	_filter	=	value;	}
		}

	}
}
