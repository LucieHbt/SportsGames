using UnityEngine;
using System.Collections;

public class postBehaviour : MonoBehaviour {
	

	//WHEN A GOAL IS SCORED -1 SEC
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name.Contains("sgk_ball"))
        {
			GetComponent<AudioSource>().Play ();
		}
	}
}
