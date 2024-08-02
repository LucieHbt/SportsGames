using UnityEngine;
using System.Collections;

namespace supergoalkeeper{
public class PlayerController : MonoBehaviour {

	//COLLECTED OBJECTS
	public int collectedObjects			=	0;
	public int totalCollectedObjects 	= 	0;
	//COLLECTED COINS
	public int coins					=	0; 

	private Transform _gloves;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void OnEnable()
	{
		_gloves=transform.Find("glove");
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name.Contains("sgk_ball"))
        {
                GetComponent<AudioSource>().Play();
                OnObjectCollision();
                this.collectedObjects++;
                this.totalCollectedObjects++;

        } else if (other.name.Contains("sgk_coin")) {
                GetComponent<AudioSource>().Play();
                this.coins++;
        }
	}
	/// <summary>
	/// on ball collision.
	/// </summary>
	private void OnObjectCollision()
	{
		if(_gloves!=null)
		{
			if(_gloves.GetComponent<Animator>()!=null)
			{
				_gloves.GetComponent<Animator> ().SetTrigger ("stopped");
			}
		}
	}
}
}