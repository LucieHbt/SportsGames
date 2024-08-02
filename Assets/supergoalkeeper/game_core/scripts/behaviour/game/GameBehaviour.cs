using UnityEngine;
using System.Collections;
using achievement_system;
using System.Collections.Generic;

namespace game_core{
/// <summary>
/// Game behaviour class is a test system to verify the right
/// operation of code.
/// </summary>
public class GameBehaviour : MonoBehaviour {
	
	public 	missionAccomplishedFilter 	saveThePrince;
	public	amountReachedFilter			collectedCoins;
	public 	timeOutFilter				timeOut;
	
	private TextView 	iLevel;
	private TextView 	iCrono;
	private BarView 	iHealth;
	private TextView 	iCoins;
	private PanelView	gameOverMenu;
	private PanelView	pauseMenu;
	private StarView	star1;
	private StarView	star2;
	private StarView	star3;
	private bool		endMission				=	false;
	private ButtonView	pauseButton;

	//ACHIEVEMENT SYSTEM
	private achievement[]	_achivements;
	private float 			achievementPoints	=	0.0f;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Awake(){
		Init();
	}

	/// <summary>
	/// This method initializes the game 
	/// variables.
	/// </summary>
	void Init()
	{
		//VIEW
		iLevel 			=	new TextView 	("level");
		iCrono			=	new TextView 	("crono");
		iCoins 			= 	new TextView 	("coins");
		iHealth 		= 	new BarView 	("health_bar");
		gameOverMenu 	= 	new PanelView 	("gameOverMenu");
		pauseMenu 		= 	new PanelView 	("pauseMenu");
		star1 			= 	new StarView ("star_1");
		star2 			= 	new StarView ("star_2");
		star3 			= 	new StarView ("star_3");
		pauseButton 	= 	new ButtonView ("pause_button");

		//MENU
		gameOverMenu.active = false;
		pauseMenu.active 	= false;

		//MISSION
		_achivements = GameObject.FindObjectsOfType <achievement>();
		for(int i=0 ; i<_achivements.Length; i++)
		{
				switch(i)
				{
				case 1:
					_achivements[i].filter=saveThePrince;
					break;
				case 2:
					_achivements[i].filter=timeOut;
					break;
				default:
					_achivements[i].filter=collectedCoins;
					break;

				}
		}

		//TIME
		TimeManager.time 		= 0.0f;
		TimeManager.isPaused 	= false;
	}

	/// <summary>
	/// This method  is called once per frame.
	/// </summary>
	void Update () {
		if (!endMission) 
		{
			TimeManager.timeScale = (TimeManager.isPaused) ? 0 : 1;
			pauseMenu.active = TimeManager.isPaused;
			iLevel.text = "Lv " + "23";

			if(TimeManager.time>=5.0f)
			{
				saveThePrince.missionFlag=(Random.Range(0,2)>0);
			}

			if (TimeManager.time <= 10.0f) 
			{
				iCoins.text = 4000 + "";
				TimeManager.time += TimeManager.deltaTime;
				timeOut.time	=	TimeManager.time;
				iCrono.text = TimeManager.time.ToString ("00") + " sec";
				iHealth.value = 50.0f;
			} else {
				GameOver();
			}
		}
	}

	/// <summary>
	/// This method ends the game properly.
	/// </summary>
	void GameOver()
	{
		endMission = true;
		pauseButton.interactable 	= false;
		collectedCoins.value 		= Random.Range (950,1500);
		Debug.Log ("coins "+collectedCoins.value);
		Debug.Log ("mission1 "+saveThePrince.missionFlag);
		Debug.Log ("timeOut "+timeOut.time+" timeLimit "+timeOut.timeLimit);
		foreach (achievement a in GameObject.FindObjectsOfType<achievement>()) 
		{
				if(a.isAccomplished){
					achievementPoints+=a.weight;
				}
		}
		StatsController.score 		+= (int)achievementPoints;
		StatsController.superScore 	+= (int)achievementPoints;
		StatsController.coins 		+= (int)collectedCoins.value;
		StatsController.level 		= 3;
		int stars =(int) achievementPoints/1000;
		switch(stars)
		{
			case 1:
				star1.activeStar = true;
				star2.activeStar = false;
				star3.activeStar = false;
				break;
			case 2:
				star1.activeStar = true;
				star2.activeStar = true;
				star3.activeStar = false;
				break;
			case 3:
				star1.activeStar = true;
				star2.activeStar = true;
				star3.activeStar = true;
				break;
			default:
				if(stars > 3)
				{
					star1.activeStar = true;
					star2.activeStar = true;
					star3.activeStar = true;
				}else{
					star1.activeStar = false;
					star2.activeStar = false;
					star3.activeStar = false;
				}
				break;

		}
		gameOverMenu.active	=	true;
	}
}
}