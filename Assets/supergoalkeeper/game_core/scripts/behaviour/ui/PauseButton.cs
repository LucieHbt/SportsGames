using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace game_core{
/// <summary>
/// Pause button.
/// </summary>
public class PauseButton : ButtonBehaviour{

	/// <summary>
	/// Execute aciton(OnClick).
	/// </summary>
	protected override void action()
	{
		TimeManager.isPaused 	= 	!TimeManager.isPaused;
	}
}
}