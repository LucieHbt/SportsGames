using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace game_core{

/// <summary>
	/// Sound canvas button class; Enable/Disable sound.
/// </summary>
public class SoundCanvasButton : ButtonBehaviour {
	public 	Sprite 	buttonNormal;
	public 	Sprite 	buttonPushed;
	private bool	volumeFlag	=	false;
	private Image	image;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	protected override void Start(){
		base.Start ();
		image					=	GetComponent<Image> ();
		volume					=	SettingsManager.sound;
		image.sprite			=	(volume>0)?	buttonNormal	:	buttonPushed;
	}

	/// <summary>
	/// Action this instance.
	/// </summary>
	protected override void action()
	{
		volumeFlag 					= 	!volumeFlag;
		volume 						= 	(volumeFlag)?	1:0;
		image.sprite				=	(volumeFlag)?	buttonNormal:buttonPushed;
		SettingsManager.sound 		= 	volume;
	}
	
	/// <summary>
	/// Gets or sets the volume.
	/// </summary>
	/// <value>The volume.</value>
	private float volume
	{
		get{return AudioListener.volume;}
		set{AudioListener.volume=value;}
	}
}

}
