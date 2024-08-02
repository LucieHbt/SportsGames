using UnityEngine;
using System.Collections;

namespace game_core{
/// <summary>
/// Object pool class creates and manages object instances.
/// </summary>
public class ObjectPool : MonoBehaviour {

	public GameObject[] objectPool;
	public int 			numberOfObjects	=	0;
	public GameObject	prefab;
	
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Awake () {
		objectPool = new GameObject[numberOfObjects];
		initObjectArray ();
	}

	/// <summary>
	/// This method initializes the objects array.
	/// </summary>
	private void initObjectArray()
	{
		if(prefab!=null)
		{
			for(int i=0;i<numberOfObjects;i++)
			{
				objectPool[i]=Instantiate(prefab) as GameObject;
				objectPool[i].SetActive(false);
			}
		}
	}

	/// <summary>
	/// This method gets the first available gameObject in the array.
	/// </summary>
	public GameObject activateObject()
	{
		for(int i=0;i<objectPool.Length;i++)
		{
			if(!objectPool[i].activeSelf)
			{
				return objectPool[i];
			}
		}
		return null;
	}
}
}