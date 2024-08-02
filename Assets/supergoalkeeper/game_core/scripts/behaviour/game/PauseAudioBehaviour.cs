using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Music behaviour on game pause.
/// </summary>
public class PauseAudioBehaviour : MonoBehaviour {

	private AudioSource _aSource;
	 
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		_aSource=GetComponent<AudioSource>();
	}
	
	//
	/// <summary>
	///  Update is called once per frame.
	/// </summary>
	void Update () {

		if (TimeManager.isPaused) 
		{
			_aSource.Pause();
		} else {
			if(!_aSource.isPlaying)
			{
				_aSource.UnPause();		
			}
		}
	
	}
}
}
