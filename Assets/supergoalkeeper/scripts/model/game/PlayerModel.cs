using UnityEngine;
using System.Collections;
namespace  supergoalkeeper{
public class PlayerModel{
	
	private GameObject mGameObject;
	
	public PlayerModel(GameObject go)
	{
		mGameObject 	= 	go;
		
		if ( mGameObject == null )
		{
			Debug.LogWarning("Cannot initialize object ");
		}
	}
	
	
	/// <summary>
	/// Games the object.
	/// </summary>
	/// <returns>The object.</returns>
	public GameObject gameObject
	{
		get
		{
			return mGameObject;
		}
	}
	
	/// <summary>
	/// Transform this instance.
	/// </summary>
	public Transform transform
	{
		get
		{
			return mGameObject.transform;
		}
	}	
	
	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <value>The position.</value>
	public Vector3 position
	{
		
		get
		{
			return transform.position;
		}
		
	}
	
	public int savedGoals
	{
			get{
				if(ComponentBehaviour!=null)
				{
					return ComponentBehaviour.totalCollectedObjects;
				}
				return 0;

			}
		}
	public int coins
	{
		get{
			if(ComponentBehaviour!=null)
			{
				return ComponentBehaviour.coins;
			}
			return 0;
		}
	}
	public int collectedBalls
	{
		set{
				if(ComponentBehaviour!=null)
				{
					ComponentBehaviour.collectedObjects=value;
				}

			}
		get{
			if(ComponentBehaviour!=null)
			{
					return ComponentBehaviour.collectedObjects;
			}
			return 0;
		}
	}
	/// <summary>
	/// Gets the hero controller component.
	/// </summary>
	/// <value>The hero controller component.</value>
	public PlayerController ComponentBehaviour
	{
		get
		{
			if(gameObject==null)	{ return null;}
			return gameObject.GetComponent( typeof( PlayerController )) as PlayerController;
		}
	}
}
}