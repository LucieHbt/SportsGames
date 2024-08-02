using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// This class sets the particle sorting layer in 2D perspective.
/// </summary>
public class particleSortingLayer : MonoBehaviour {
	public int 		order		=	0;
	public string 	layerName	=	"foreground";

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = layerName;
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = order;
	}
	

}
}