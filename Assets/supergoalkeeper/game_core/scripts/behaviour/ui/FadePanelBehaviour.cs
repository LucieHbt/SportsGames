using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace game_core{
/// <summary>
/// Fade panel behaviour class; makes that panels 
/// (dis)appear on the screen smoothly.
/// </summary>
public class FadePanelBehaviour : MonoBehaviour {
	//VARIABLES
	public 	float 	fadeTime	=	1.0f;
	public	bool	fadeInFlag	=	true;
	private Image 	_image;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() 
	{
		_image	=	GetComponent<Image> ();
			if(fadeInFlag)
			{
				fadeIn();
			}else{
				StartCoroutine (fadeOut());
			}
	}

	/// <summary>
	/// Fade IN.
	/// </summary>
	public void fadeIn()
	{
		_image.canvasRenderer.SetAlpha( 0.0f );
		_image.CrossFadeAlpha(1.0f, fadeTime, true);
	}

	/// <summary>
	/// Fade OUT.
	/// </summary>
	IEnumerator fadeOut()
	{
		float alpha = 1.0f;
		_image.canvasRenderer.SetAlpha (alpha);
		while (alpha > 0.1f && fadeTime>0) 
		{
			alpha-=0.1f;
			_image.canvasRenderer.SetAlpha (alpha);
			yield return new WaitForSeconds ((fadeTime/10.0f));
		}
		gameObject.SetActive (false);
	}
}
}