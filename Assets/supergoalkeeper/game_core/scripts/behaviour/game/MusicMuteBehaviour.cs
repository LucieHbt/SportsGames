using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Music mute configuration.
/// </summary>
public class MusicMuteBehaviour : MonoBehaviour {
	
	private AudioSource aSource;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Awake() 
	{
		aSource=GetComponent<AudioSource> ();
		setActive (SettingsManager.music);
	}

	/// <summary>
	/// This method  is called once per frame.
	/// </summary>
	void FixedUpdate(){
			setActive (SettingsManager.music);	
	}

	/// <summary>
	/// Enable/Disable audio.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void setActive(bool value)
	{
		if(!TimeManager.isPaused)
		{
			if (value){
					if(!aSource.isPlaying)
					{
						aSource.Play();
					}
			} else {
					aSource.Stop();
			}
		}
	}
}
}