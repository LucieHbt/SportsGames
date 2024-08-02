using UnityEngine;
using System.Collections;

namespace supergoalkeeper{

public class Mover : MonoBehaviour {

	//FORCE OF  BALL
	private float 	forceBall;

	//MAIN CAMERA
	public 	Camera 	cam;

	//TIME TO START THE BALL EFFECT
	// Default Config. Vector2(0,0)
	public 	Vector2 startWait;

	//DURATION OF BALL CURVE
	//by default Vector2(0.5,0.65)
	public Vector2 ballCurveTime;

	//DURATION OF REVERSE BALL CURVE
	//by default Vector2(1,1)
	public Vector2 ballCurveWait;

	//BALL TORQUE
	//by default spin=0.5f
	public 	float 	spin			=0f;

	//START/END FORCE
	//by default startForce=10; endForce=20;
	public 	float 	startForce		=0.0f;
	public 	float 	endForce		=5.0f;
	
	//START
	void Start ()
	{
		if(!cam)		{this.cam=Camera.main;}
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable(){
			StartCoroutine(Parabola());
	
	}

	//THE BALL DESCRIBES A PARABOLA
	IEnumerator Parabola ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		forceBall = Random.Range (startForce, endForce) * -Mathf.Sign (transform.position.x);
		yield return new WaitForSeconds (Random.Range (ballCurveTime.x, ballCurveTime.y));
		forceBall =-forceBall;
		yield return new WaitForSeconds (Random.Range (ballCurveWait.x, ballCurveWait.y));
		forceBall = 0;
	}

	/**
	 * THE BALL SPINS.
	 * THE BALL DESCRIBES A PARABOLA.
	 * */
	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().AddForce (new Vector2(forceBall,0.0f));
		GetComponent<Rigidbody2D>().AddTorque(spin);
	}


}

}