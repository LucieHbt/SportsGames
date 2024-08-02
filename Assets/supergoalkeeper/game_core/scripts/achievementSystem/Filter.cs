using UnityEngine;
using System.Collections;

namespace achievement_system{
	/// <summary>
	/// Filter abstract class define a set of operations which
	/// all objects that implement class must support.
	/// </summary>
	public abstract class Filter{
		/// <summary>
		/// Initializes a new instance of the <see cref="Filter"/> class.
		/// </summary>
		public Filter(){}

		/// <summary>
		/// Test this instance.
		/// </summary>
		public abstract bool test();

	}
}