using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace game_core{
/// <summary>
	/// Legal behaviour class; manage legal text saved in PlayerPrefs.
/// </summary>
public class legalBehaviour : MonoBehaviour {

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		string legal	=	PlayerPrefs.GetString ("legal");

		if (legal != "") {
						GetComponent<Text> ().text = legal;
		}
	}
}
}