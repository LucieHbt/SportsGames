using UnityEngine;
using System.Collections;
namespace game_core{
	/// <summary>
	/// DestroyOnContact class defines the behaviour of gameObject
	/// when collide with other.
	/// </summary>
	public class DestroyOnContact : MonoBehaviour 
	{
		public bool destroy	=	true;

		/// <summary>
		/// On collision detected object(other) is removed/disabled.
		/// </summary>
		/// <param name="other">Other.</param>
		void OnTriggerEnter2D(Collider2D other)
		{
			if (destroy) {
				Destroy (other.gameObject);
			} else {
				other.gameObject.SetActive(false);			
			}
		}
	}
}
