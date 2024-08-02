using UnityEngine;
using System.Collections;
namespace game_core
{
/// <summary>
/// Sound view class; Abstraction layer to deal with UI elements(Sound in this case).
/// </summary>
public class SoundView {
	private string 		_GameObjectName 	= 	"music";
	private bool 		_active				=	false;
	private GameObject	_GameObject;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="SoundView"/> class.
	/// </summary>
	public SoundView(string name)
	{
		_GameObjectName	=	(name!="")?	name	:	_GameObjectName;
		_GameObject 	= 	GameObject.Find( _GameObjectName);
	}
	
	
	/// <summary>
	/// Games the object.
	/// </summary>
	/// <returns>The object.</returns>
	public GameObject gameObject
	{
		get
		{
			return _GameObject;
		}
	}
	
	/// <summary>
	/// Transform this instance.
	/// </summary>
	public Transform transform
	{
		get
		{
			return _GameObject.transform;
		}
	}	
	
	/// <summary>
	/// Transform this instance.
	/// </summary>
	public AudioSource audioSource
	{
		get
		{
			if(gameObject==null)	{ return null;}
			return transform.GetComponent<AudioSource>();
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

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="IndicatorView"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	public bool active
	{
		set{
			_active	=	value;
			if(gameObject!=null)
			{
				gameObject.SetActive(value);
			}
		}
		get{
			return _active;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="SoundView"/> is play.
	/// </summary>
	/// <value><c>true</c> if play; otherwise, <c>false</c>.</value>
	public bool play
	{
		set{
			if(audioSource!=null)
			{
				if(value==true)
				{
					audioSource.UnPause();
					if(!audioSource.isPlaying){audioSource.Play();}
				}else{
					audioSource.Pause();
				}
			}
		}
		get{
			return (audioSource!=null && audioSource.isPlaying);
		}
	}

	/// <summary>
	/// Gets or sets the volume.
	/// </summary>
	/// <value>The volume.</value>
	public float volume
	{
		set{
			if(audioSource!=null)
			{
				audioSource.volume=value;
			}

		}
		get{
			if(audioSource!=null){return audioSource.volume;}
			return 0f;
		}
	}

	/// <summary>
	/// Gets or sets the pitch.
	/// </summary>
	/// <value>The pitch.</value>
	public float pitch
	{
		set{
			if(audioSource!=null)
			{
				audioSource.pitch=value;
			}
		}
		get{
			if(audioSource!=null){return audioSource.pitch;}
			return 0f;
		}
	}
	
}
}