using UnityEngine;
using System.Collections;
namespace supergoalkeeper{
public class GoalModel{

	private string mGameObjectName = "goal";
	private GameObject mGameObject;
	
	public GoalModel(string name)
	{
		mGameObjectName	=	(name!="")?name:mGameObjectName;
		mGameObject 	= 	GameObject.Find( mGameObjectName);
		
		if ( mGameObject == null )
		{
			Debug.LogWarning("Cannot find object template " + mGameObjectName );
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
	
	public int goals
	{
		get{
			if(ComponentBehaviour!=null)
			{
				return ComponentBehaviour.goals;
			}
			return 0;
		}
	}
	/// <summary>
	/// Gets the hero controller component.
	/// </summary>
	/// <value>The hero controller component.</value>
	public goalController ComponentBehaviour
	{
		get
		{
			if(gameObject==null)	{ return null;}
			return gameObject.GetComponent( typeof( goalController )) as goalController;
		}
	}
}
}