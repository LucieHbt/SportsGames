using UnityEngine;
using System.Collections;

namespace game_core{
	/// <summary>
	/// BoundaryBehaviour class defines the behaviour of boundary 
	/// when a gameObject leaves from game zone.
	/// </summary>
	public class BoundaryBehaviour : MonoBehaviour {
		public bool destroy=true;

		/// <summary>
		/// When objects leave from game zone are removed/disabled.
		/// </summary>
		/// <param name="other">Other.</param>
		void OnTriggerExit2D(Collider2D other)
		{
			if (destroy) 
			{
					Destroy (other.gameObject);
			} else {
					other.gameObject.SetActive (false);
			}
		}
	}

}
