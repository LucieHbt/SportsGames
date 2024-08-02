using UnityEngine;
using System.Collections;

namespace game_core{
/// <summary>
/// Screen shake effect behaviour.
/// </summary>
public class ScreenShakeBehaviour : MonoBehaviour {

	/// <summary>
	/// Transform of the camera to shake. Grabs the gameObject's transform
	/// if null.
	/// </summary>
	public Transform camTransform;
	
	/// <summary>
	/// How long the object should shake for.
	/// </summary>
	public bool onEnableShake=true;
	public float shake 			= 0f;

	/// <summary>
	/// Amplitude of the shake. A larger value shakes the camera harder.
	/// </summary>
	public float shakeAmount 	= 0.7f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = Camera.main.GetComponent(typeof(Transform)) as Transform;
		}
	}

	/// <summary>
	/// Screen Shake effect coroutine.
	/// </summary>
	IEnumerator Shake(){
		float sValue 	= shake;
		while(sValue>0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			sValue-=Time.deltaTime*decreaseFactor;
			yield return null;
		}
		originalPos = camTransform.localPosition;
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable(){
		originalPos = camTransform.localPosition;
		if (onEnableShake) {
			OnShake();
		}

	}

	/// <summary>
	/// Raises the shake event.
	/// </summary>
	public void OnShake()
	{
		originalPos = camTransform.localPosition;
		StartCoroutine (Shake());
	}
}
}