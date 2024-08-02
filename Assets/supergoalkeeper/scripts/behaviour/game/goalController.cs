using UnityEngine;
using System.Collections;
namespace supergoalkeeper{
public class goalController : MonoBehaviour {

	/**
	 * VARIABLES
	 * */
	public int 				blinkTimes	=	3;//TIMER BLINK SET UP
	public GameObject		timer;		 // GUITEXT TIME
	public int 				goals		=	0;
	

	//COROUTINE TIMER BLINK, TIMER BLINKS WHEN A GOAL IS SCORED
	//IEnumerator timerBlink()
	//{
	//	for(int i=0;i<3 ;i++)
	//	{
			/*this.timer.guiText.color=Color.red;*/
	//		yield return new WaitForSeconds(0.2f);
			/*this.timer.guiText.color=Color.white;*/
	//		yield return new WaitForSeconds(0.2f);
	//	}
	//}

	//WHEN A GOAL IS SCORED -1 SEC
	void OnTriggerEnter2D(Collider2D other)
	{
            //if(other.tag=="object" || other.tag=="object2")

        if(other.name.Contains("sgk_ball"))
        {
			goals++;
			GetComponent<AudioSource>().Play ();
		}
		other.gameObject.SetActive (false);
		//Destroy (other.gameObject);
	}
}
}