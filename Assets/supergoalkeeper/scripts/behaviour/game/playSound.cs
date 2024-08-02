using UnityEngine;
using System.Collections;

namespace supergoalkeeper{
	public class playSound : MonoBehaviour {

		void OnCollisionEnter2d(Collision2D other)
		{
			if(other.gameObject.tag=="Player")
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
}