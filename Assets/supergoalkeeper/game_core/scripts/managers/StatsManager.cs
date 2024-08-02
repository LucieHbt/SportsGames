using UnityEngine;
using System.Collections;
namespace game_core{

/// <summary>
	/// Stats controller class; Deals with player stats saved in PlayerPref.
/// </summary>
public static class StatsController{

	/// <summary>
	/// Gets the name of the int by.
	/// </summary>
	/// <returns>The int by name.</returns>
	/// <param name="value">Value.</param>
	public static int GetIntByName(string value)
	{
		return PlayerPrefs.GetInt (value);
	}

	/// <summary>
	/// Gets the name of the float by.
	/// </summary>
	/// <returns>The float by name.</returns>
	/// <param name="value">Value.</param>
	public static float GetFloatByName(string value)
	{
		return PlayerPrefs.GetFloat (value);
	}

	/// <summary>
	/// Gets the name of the string by.
	/// </summary>
	/// <returns>The string by name.</returns>
	/// <param name="value">Value.</param>
	public static  string GetStringByName(string value)
	{
		return PlayerPrefs.GetString (value);
	}

	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	/// <value>The score.</value>
	public static int score
	{
		get{	return PlayerPrefs.GetInt("score");	}
		set{	PlayerPrefs.SetInt("score",value);	}
	}

	/// <summary>
	/// Gets or sets the super score.
	/// </summary>
	/// <value>The super score.</value>
	public static int superScore
	{
		get{	return PlayerPrefs.GetInt("superScore");}
		set{	PlayerPrefs.SetInt("superScore",value);}
	}

	/// <summary>
	/// Gets or sets the level.
	/// </summary>
	/// <value>The level.</value>
	public static int level
	{
		get{ return PlayerPrefs.GetInt("level");}
		set{ PlayerPrefs.SetInt("level",value);}
	}

	/// <summary>
	/// Gets or sets the coins.
	/// </summary>
	/// <value>The coins.</value>
	public static int coins
	{
		get{ return PlayerPrefs.GetInt("coins");}
		set{ PlayerPrefs.SetInt("coins",value);}
	}
}
}