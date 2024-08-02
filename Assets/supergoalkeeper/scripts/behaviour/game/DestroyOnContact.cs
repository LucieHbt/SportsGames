using UnityEngine;
using System.Collections;

namespace supergoalkeeper{
	public class DestroyOnContact : MonoBehaviour {
		//ON COLLISION WITH GLOVE OBJECT IS REMOVED
		void OnTriggerEnter2D(Collider2D other)
		{
            if (other.name.Contains("sgk_coin") || other.name.Contains("sgk_ball"))
            {
				other.gameObject.SetActive(false);
				//Destroy (other.gameObject);
			}

		}
	}
}
