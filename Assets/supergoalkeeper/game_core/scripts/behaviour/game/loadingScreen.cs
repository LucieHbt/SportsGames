using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Loading screen.
/// </summary>
public class loadingScreen : MonoBehaviour {
	/// <summary>
	/// The color of the background.
	/// </summary>
	public Color backgroundColor	=	Color.black;
	/// <summary>
	/// The color of the text.
	/// </summary>
	public Color textColor			=	Color.white;
	/// <summary>
	/// The message shown on screen.
	/// </summary>
	public string message			=	"Loading ...";

	/// <summary>
	/// The style of GUI.
	/// </summary>
	public GUIStyle style;

	
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		Time.timeScale = 1;
		Camera.main.backgroundColor = backgroundColor;
	}

	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI(){
		//CACHE AND UPDATE GUI SETTINGS
		Color cachedColor 	= GUI.contentColor;
		GUI.contentColor 	= textColor;

		//DRAW LABEL
		float width 	= 100f;
		float height 	= 20f;
		float left 		= Screen.width / 2 - width;
		float top 		= Screen.height / 2 - height;
		Rect rect 		= new Rect (left,top,width,height);
		GUI.Label (rect,message,style);

		//RESTORE GUI SETTINGS
		GUI.contentColor	= cachedColor;
	}
}
}