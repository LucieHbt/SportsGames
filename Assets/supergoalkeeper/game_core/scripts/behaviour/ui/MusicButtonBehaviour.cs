using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace game_core{
	/// <summary>
	/// Music button behaviour class; Enable/Disable music.
	/// </summary>
	public class MusicButtonBehaviour : ButtonBehaviour {
		public 	Sprite 	buttonNormal;
		public 	Sprite 	buttonPushed;
		private bool	musicFlag	=	false;
		private Image	image;
		
		/// <summary>
		/// Use this for initialization.
		/// </summary>
		protected override void Start(){
			base.Start ();
			image					=	GetComponent<Image> ();
			musicFlag				=	SettingsManager.music;
			image.sprite			=	(musicFlag)?	buttonNormal	:	buttonPushed;
		}
		
		/// <summary>
		/// Execute action(OnClick).
		/// </summary>
		protected override void action()
		{
			musicFlag 					= 	!musicFlag;
			image.sprite				=	(musicFlag)?	buttonNormal:buttonPushed;
			SettingsManager.music 		= 	musicFlag;
		}
	}
	
}