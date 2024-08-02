using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace achievement_system{

	[System.Serializable]
	/// <summary>
	/// time filter; it tests whether the time is over.
	/// </summary>
	public class timeOutFilter : Filter {
		private float	_time		=	0.0f;
		public  float 	timeLimit	=	0.0f;

		/// <summary>
		/// Initializes a new instance of the <see cref="game_core.timeOutFilter"/> class.
		/// </summary>
		public timeOutFilter(){}

		/// <summary>
		/// Test this instance.
		/// </summary>
		public override bool test ()
		{
			return (_time > timeLimit);
		}

		/// <summary>
		/// Gets or sets the time.
		/// </summary>
		/// <value>The time.</value>
		public float time{
			get{	return 	_time;		}
			set{	_time	=	value;	}
		}
	}

	[System.Serializable]
	/// <summary>
	/// Dichotomic filter; it tests whether the mission is accomplished.
	/// </summary>
	public class missionAccomplishedFilter : Filter {
		public bool missionFlag = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="game_core.timeOutFilter"/> class.
		/// </summary>
		public missionAccomplishedFilter(){}

		/// <summary>
		/// Test this instance.
		/// </summary>
		public override bool test ()
		{
			return missionFlag;
		}
	}

	[System.Serializable]
	/// <summary>
	/// Quantitative filter; it tests whether the desired amount is reached.
	/// </summary>
	public class amountReachedFilter : Filter {
		private float	_value		=	0.0f;
		public float 	target		=	0.0f;

		/// <summary>
		/// Initializes a new instance of the <see cref="game_core.timeOutFilter"/> class.
		/// </summary>
		public amountReachedFilter(){}
		
		/// <summary>
		/// Test this instance.
		/// </summary>
		public override bool test ()
		{
			return (_value	>=	target);
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public float value
		{
			set{	_value	=	value;	}
			get{ 	return 	_value;		}
		}
	}
}