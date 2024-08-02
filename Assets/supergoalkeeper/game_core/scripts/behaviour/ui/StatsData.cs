using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace game_core{
	/// <summary>
	/// Stats data class; manages the stats saved in PlayerPrefs.
	/// </summary>
	public class StatsData : MonoBehaviour {
		public 	string variableName="";

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{

			string value	=	(StatsController.GetStringByName (variableName)					!="")?	StatsController.GetStringByName (variableName):
								((StatsController.GetIntByName(variableName).ToString("00")		!="00")?	StatsController.GetIntByName(variableName).ToString("00"):	
				 				((StatsController.GetFloatByName(variableName).ToString("00.00")!="00.00")?	StatsController.GetFloatByName(variableName).ToString("00.00"):"-")
				 				);
			GetComponent<Text> ().text = value;
		}
	}
}
