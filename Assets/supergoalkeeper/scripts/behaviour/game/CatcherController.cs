using UnityEngine;
using System.Collections;
namespace supergoalkeeper{

public class CatcherController : MonoBehaviour {
	/**
	 * VARIABLES
	 * */
	public Camera cam;     //MAIN CAMERA
	private float maxWidth;// MAX WIDTH GAME SCENE

	// Use this for initialization
	void Start () {
		if(!cam)
		{
			cam=Camera.main;
		}

		//DEFINE THE PLAYABLE ZONE
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height,0.0f);
		Vector3 targetWidth	= cam.ScreenToWorldPoint(upperCorner);
		float catcherwidth 	= GetComponent<Renderer>().bounds.extents.x;
		maxWidth 			= targetWidth.x-catcherwidth;
	}
	
	// Update is called once per  physics timestep
	void FixedUpdate () {
		//TRANSLATE THE CLICK/TOUCH POS TO GAME POINT
		Vector3 rawPosition		= cam.ScreenToWorldPoint(Input.mousePosition);

		//SET THE NEW POS OF CATCHER
		Vector3 targetPosition 	= new Vector3 (rawPosition.x,this.transform.position.y,0.0f);

		//DEFINE THE PLAYABLE ZONE
		float targetWidth 		= Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);

		//SET THE NEW POS OF CATCHER 
		targetPosition 			= new Vector3 (targetWidth, targetPosition.y, targetPosition.z);

		//MOVE CATCHER
		transform.position 		= targetPosition;
	}
}

}