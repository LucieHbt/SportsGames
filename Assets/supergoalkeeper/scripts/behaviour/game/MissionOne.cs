using UnityEngine;
using System.Collections;
using game_core;

namespace supergoalkeeper{

public class MissionOne : MonoBehaviour {

		/// <summary>
		/// VARIABLES.
		/// </summary>
		//MAIN CAMERA
		public 	Camera 				cam;	

		//GLOVES ARRAY
		public 	GameObject[]		gloves;	

		//TERRAIN ARRAY
		public	GameObject[]		grassList;			

		//BALL ARRAY
		public 	GameObject[]		objectGame;	
		public	GameObject[]		objectGamePool;

		//GAME TERRAIN
		public 	GameObject			grass;

		//GAMEOBJECTS
		public	GameObject 			coin;
		public	GameObject[]		coinPool;

		//GOAL
		public GoalModel			goal;
		
		//PLAYER CONTROLLER SCRIPT
		public 	PlayerModel  		player; 

		//GAME DURATION
		public 	float 				gameDuration		=	30.0f;		

		//GAMEOVER FLAG
		public 	bool 				gameOver 			= 	false;	//GAMEOVER FLAG INDICATES END OF GAME

		//GOALS AMOUNT
		public 	float				seconds				=	2.0f;
		public 	float				penaltyTime			=	1.0f;
		public 	int 				balls4Cash 			= 	4;
		public 	int					spawnNCoins 		= 	2;
		//SPAWNER TIME RANGE
		public Vector2 timeRange						=	new Vector2(1.0f,2.0f);

		//MAXWIDTH INDICATES MAX WIDTH OF GAME SCENE
		private float 				maxWidth;			

	

		//GAME CONTROL VARIABLES
		private int 	oldCollectedObjects = 	0;
		private int		oldScoredGoals 	= 	0;
		private bool 	missionEnd		=	false;
		private int		oldCoins		=	0;
		//GAME INDICATORS
		private TextView	iLevel;
		private TextView	iCrono;
		private BarView		iHealth;//NOT IN USE
		private TextView	iCoins;
		private GameObject	iLevelUp;

		//GAME MENU
		private GameObject	gameOverMenu;
		private GameObject	pauseMenu;



		//FACTOR TO INCREASE LEVEL
		//THIS ADJUST THE DIFFICULTY OF GAME
		//FOR EXAMPLE factorLevel=4
		// LV 1 2*4 	=8 		Objects needed to promote LEVEL2
		// LV 2 (2+1)*4	=12 	Objects needed to promote LEVEL3
		// LV 3 (2+2)*4	=16 	Objects needed to promote LEVEL4
		public 	int factorLevel		=	4; 
		//LEVEL NUMBER
		public int level			=	1;
		//NUMBER OF OBJECTS TO INCREASE LEVEL
		public int levelUp			=	0;

		/// <summary>
		/// Use this for initialization.
		/// </summary>
		void Start () {
			volume			=	SettingsManager.sound;
			goal 			= 	new GoalModel ("sgk_goal");
			iLevel 			=	new TextView ("level");
			iCrono			=	new TextView ("crono");
			iCoins 			= 	new TextView ("coins");
			iLevelUp 		= 	GameObject.Find("levelUp");
			gameOverMenu 	= 	GameObject.Find("gameOverMenu");
			pauseMenu 		= 	GameObject.Find("pauseMenu");
			Init();
		}
		
		/// <summary>
		/// Inits the time.
		/// </summary>
		void Init()
		{
			//CAMERA
			if(!cam)
			{
				cam=Camera.main;
			}

			//MENU
			gameOverMenu.SetActive (false);
			pauseMenu.SetActive (false);

			//LEVELUP
			iLevelUp.SetActive (false);

			//TIME
			TimeManager.time 		= 	gameDuration;
			TimeManager.isPaused 	= 	false;

			//PLAYER
			if(gloves.Length>0){
				player	=	new PlayerModel(	Instantiate (gloves[SettingsManager.selectedID], gloves[SettingsManager.selectedID].transform.position ,Quaternion.Euler(new Vector3(0,0,0))) as GameObject);
			}

			//OBJECTS
			initObjectArray ();

			//TERRAIN
			if(grassList.Length>0)
			{
				int grassID				=	Random.Range (0,grassList.Length);
				this.grass				=	Instantiate (grassList[grassID], grassList[grassID].transform.position ,Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			}

			//START GAME
			if(objectGame.Length>0)
			{
				StartCoroutine (Spawn());
			}

		}
	
	/// <summary>
	/// Inits the object array.
	/// </summary>
	private void initObjectArray()
	{
		if(objectGame != null)
		{
			objectGamePool=new GameObject[objectGame.Length];
			for(int i=0; i < objectGame.Length;i++) 
			{
				objectGamePool[i]=Instantiate(objectGame[i]) as GameObject;
				objectGamePool[i].SetActive(false);
			}
		}
		if(coin!=null)
		{
			coinPool=new GameObject[spawnNCoins];
			for(int i=0;i< this.spawnNCoins ;i++)
			{
				coinPool[i]=Instantiate(this.coin) as GameObject;
				coinPool[i].SetActive(false);
			}
		}
	}

	/// <summary>
	/// Activates the object.
	/// </summary>
	public GameObject activateObject(int index=0)
	{

		if (!objectGamePool [index].activeSelf) 
		{
				return objectGamePool[index] ;
		}
		for(int i=0;i<objectGamePool.Length;i++)
		{
			if(!objectGamePool[i].activeSelf)
			{
				return objectGamePool[i];
			}
		}
		return null;
	}
	/// <summary>
	/// Activates the object.
	/// </summary>
	public GameObject activateCoin()
	{
		for(int i=0;i<coinPool.Length;i++)
		{
			if(!coinPool[i].activeSelf)
			{
				return coinPool[i];
			}
		}
		return null;
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		if(!missionEnd)
		{
			if (!gameOver) {

				updateTimers();
				calculateLevel();
				updateUI();
			} else {
				this.GameOver();
			}
		}

	}

	/// <summary>
	/// Updates the timers.
	/// </summary>
	void updateTimers(){
		//updateTimers();
		//GOALS SAVED CONTROL
		if(player.collectedBalls>0 && player.collectedBalls!=oldCollectedObjects)
		{
			//COINS SPAWNER
			if((player.collectedBalls%balls4Cash)==0)
			{
				StartCoroutine(spawnCoins());
			}
			//TIME PRIZE
			TimeManager.time+=seconds;
			oldCollectedObjects=player.collectedBalls;
		}
		
		
		//GOALS CONTROL
		if(goal.goals>0 && goal.goals!=oldScoredGoals)
		{
			TimeManager.time	-=	penaltyTime;
			oldScoredGoals		=	goal.goals;
			//iCrono.ComponentBehaviour.blinkText(Color.red,3);
		}
		
		
		//TIME CONTROL
		TimeManager.timeScale 	= 	(TimeManager.isPaused) ? 0 : 1;
		pauseMenu.SetActive(TimeManager.isPaused);
		TimeManager.time 		-= 	TimeManager.deltaTime;
		if (TimeManager.time < 0) {
			this.gameOver = true;
			TimeManager.time = 0;
		}
		//END updateTimers()
	}

	/// <summary>
	/// Updates the indicators.
	/// </summary>
	void updateUI(){
		//UPDATE UI
		iCrono.text = TimeManager.time.ToString ("00") + " sec";
		iCoins.text = player.coins.ToString("0000");//PLAYER.COINS
		//COINS CONTROL
		if(player.coins>0 && player.coins!=oldCoins)
		{
			oldCoins	=	player.coins;
			//iCoins.ComponentBehaviour.blinkText(Color.yellow,3);
			
		}
	}

	/// <summary>
	/// Calculates the level.
	/// </summary>
	void calculateLevel(){
		//LEVEL CONTROL
		//CALCULATE THE OBJECTS NUMBER TO LEVEL UP
		levelUp = (2 + (level - 1)) * factorLevel;
		if(player.collectedBalls>=levelUp)
		{
			level++;
			player.collectedBalls	=	0;
			iLevel.text = "Lv "+level;//PLAYER.LEVEL
			StartCoroutine(levelUP());
		}
		
		//END CALCULATE LEVEL
	}

	/// <summary>
	/// Games the over.
	/// </summary>
	void GameOver()
	{
		//UPDATE PLAYER STATS
		updatePlayerStats ();

		//ACTIVE GAMEOVER MENU
			gameOverMenu.SetActive (true);

		//missionEnd
		missionEnd = true;

	}
		
	/// <summary>
	/// Updates the player stats.
	/// </summary>
	void updatePlayerStats()
	{
		if(player!=null && goal!=null)
		{
			
			if(level>StatsController.level){StatsController.level=level;}
				StatsController.score 		=	StatsController.score		+	goal.goals;
				StatsController.superScore 	= 	StatsController.superScore	+	player.savedGoals;
				StatsController.coins 		= 	StatsController.coins		+	player.coins;
		}
		
	}

	/// <summary>
	/// Spawn this instance.
	/// </summary>
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (2.0f);
		while (!gameOver) 
		{
			//GameObject obj=this.objectGame[Random.Range(0,(this.objectGame.Length))];
			GameObject obj=this.activateObject(Random.Range(0,(this.objectGamePool.Length)));
			if(obj!=null)
			{
				Vector3 upperCorner = new Vector3 (Screen.width, Screen.height,0.0f);
				Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
				float objectWidth = obj.GetComponent<Renderer>().bounds.extents.x;
				maxWidth = targetWidth.x - objectWidth;
				Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth),
				                                     transform.position.y,
				                                     0.0f);
				Quaternion spawnRotation 	= 	Quaternion.identity;
				obj.transform.position		=	spawnPosition;
				obj.transform.rotation		=	spawnRotation;
				obj.SetActive(true);
			}

			//Instantiate (obj, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range (timeRange.x,timeRange.y));
		}
	}

	/// <summary>
	/// Spawns the coins.
	/// </summary>
	/// <returns>The coins.</returns>
	IEnumerator spawnCoins()
	{
		yield return new WaitForSeconds (0.5f);
		for(int i=0;i<spawnNCoins;i++)
		{
			GameObject obj=activateCoin();
			if(obj!=null)
			{
				Vector3 upperCorner 		= new Vector3 (Screen.width, Screen.height,0.0f);
				Vector3 targetWidth 		= cam.ScreenToWorldPoint (upperCorner);
				float 	objectWidth			= this.coin.GetComponent<Renderer>().bounds.extents.x;
				float 	maxWidth 			= targetWidth.x - objectWidth;
				Vector3 spawnPosition 		= new Vector3 (
					Random.Range (-maxWidth, maxWidth),
					this.transform.position.y,
					0.0f
					);
				Quaternion spawnRotation	= 	Quaternion.identity;
				obj.transform.position		=	spawnPosition;
				obj.transform.rotation		=	spawnRotation;
				obj.SetActive(true);
				//Instantiate (this.coin, spawnPosition, spawnRotation);
			}
			
			yield return new WaitForSeconds(Random.Range(0.5f,0.75f));
		}
	}

	/// <summary>
	/// Levels the U.
	/// </summary>
	/// <returns>The U.</returns>
	IEnumerator levelUP()
	{
		yield return new WaitForSeconds (0.5f);
		if (iLevelUp != null) 
		{
				iLevelUp.SetActive(true);
		}
		yield return new WaitForSeconds (1.0f);
		if (iLevelUp != null) 
		{
			iLevelUp.SetActive(false);
		}
	}
	
	/// <summary>
	/// Gets or sets the volume.
	/// </summary>
	/// <value>The volume.</value>
	private float volume
	{
		get{return AudioListener.volume;}
		set{AudioListener.volume=value;}
	}
}

}
