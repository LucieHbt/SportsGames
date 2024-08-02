using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Settings manager class; Deals with player settings saved in PlayerPrefs.
/// </summary>
public static class SettingsManager {

	/// <summary>
	/// Gets or sets the selected I.
	/// </summary>
	/// <value>The selected I.</value>
	public static int selectedID
	{
		get{return PlayerPrefs.GetInt("selectedID");}
		set{PlayerPrefs.SetInt("selectedID",value);}
	}

	/// <summary>
	/// Gets or sets the sound.
	/// </summary>
	/// <value>The sound.</value>
	public static float sound
	{
		get{return PlayerPrefs.GetFloat("sound");}
		set{PlayerPrefs.SetFloat("sound",value);}
	}
	
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="game_core.SettingsManager"/> is music.
	///	0 Not initialized.
	/// 1 Music OFF.
	/// 2 Music ON .
	/// </summary>
	/// <value><c>true</c> if music; otherwise, <c>false</c>.</value>
	public static bool music
	{
		get{
				if(PlayerPrefs.GetInt("music")==0)
				{
					PlayerPrefs.SetInt("music",2);
				}
				return (PlayerPrefs.GetInt("music")>1);
			}
		set{
				int val			=	1;
				if(value){val	=	2;}
				PlayerPrefs.SetInt("music",val);
			}
	}
}
}