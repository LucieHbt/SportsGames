using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace game_core{
/// <summary>
/// Canvas button class.
/// </summary>
public class CanvasButton : ButtonBehaviour {
	public bool				saveId		=	false;
	public string			sceneName	=	"Launcher";
	public int				buttonID	=	0;
	

	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	protected override void action()
	{
		if(saveId)	{SettingsManager.selectedID	=	buttonID;}
		LevelManager.Load (sceneName);
	}
}
}