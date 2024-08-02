using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
	/// Link canvas button class; manage external links.
/// </summary>
public class LinkCanvasButton : ButtonBehaviour {
	public string 		link		=	"";

	/// <summary>
	/// Action this instance.
	/// </summary>
	protected override void action()
	{
		Application.OpenURL(link);
	}
}
}