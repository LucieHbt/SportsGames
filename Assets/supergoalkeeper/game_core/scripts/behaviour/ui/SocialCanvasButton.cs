using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
	/// Social canvas button class; Share in social media the player score.
/// </summary>
public class SocialCanvasButton : ButtonBehaviour {

	public string title			=	"GAME TITLE";
	public string url			=	"http://looneybits.com";
	public string caption		=	"GAME TITLE";
	public string description	=	"Super Score: ";
	public string hashtags 		= 	"#looneybits";
	public string variableName	=	"superScore";
	public string FBAppID		=	"1435061540094302";
	public string FBRedirectUri	=	"http://looneybits.com";

	
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	protected override void Start(){
		string website	=	PlayerPrefs.GetString ("website");
		string twitter 	= 	PlayerPrefs.GetString ("twitter");
		string facebook = 	PlayerPrefs.GetString ("fbk");
		if (website != "") 
		{
			this.url			=	website;
			this.FBRedirectUri	=	website;
		}
		if(twitter!="")
		{
			this.hashtags=twitter;
		}
		if(facebook!="")
		{
			this.FBAppID=facebook;
		}
	}
	
	/// <summary>
	/// 	PROBLEM:
	///		Right now the best solution to solve the problem of 
	///		share button with facebook is use dialog system. 
	///		Sharer system has suffered some changes.
	///		
	///		
	///		1 SOLUTION SAMPLE OF FACEBOOK DIALOGS:(CHANGE APP_ID) 
	///		http://www.facebook.com/dialog/feed?
	///		app_id=123050457758183&
	///		link=http://developers.facebook.com/docs/reference/dialogs/& picture=http://looneybits.com/assets/img/p04.png&
	///		name=Facebook%20Dialogs&
	///		caption=Reference%20Documentation& description=Dialogs%20provide%20a%20simple,%20consistent%20interface%20for%20applications%20to%20interact%20with%20users.& message=Facebook%20Dialogs%20are%20so%20easy!& redirect_uri=http://www.example.com/response
	///		
	///		REQUISITES(TWITTER DOES NOT HAVE REQUISITES)
	///		FACEBOOK ACCOUNT
	///		REGISTER AS FACEBOOK DEVELOPER
	///		APP_ID YOU MUST TO HAVE AN APP_ID. REGISTER A SIMPLE APP ON http://developers.facebook.com
	///		
	///		2 SOLUTION SAMPLE OF FACEBOOK SHARER.php (DEPRECATED HALF SOLUTION)
	///		http://www.facebook.com/sharer.php?s=100
	///		&p[title]=TITLE
	///		&p[url]=http://looneybits.com
	///		&p[summary]=yoursummaryhere
	///		&p[images][0]=http://looneybits.com/assets/img/p04.png";
	///		
	///		
	///		LITERATURE:
	///		http://stackoverflow.com/questions/5023602/facebook-share-body-text
	/// 
	/// 	WITH OLD SHARER.php
	///		string facebookshare = "https://www.facebook.com/sharer/sharer.php?t="+System.Uri.EscapeDataString(title)+"&u="+System.Uri.EscapeUriString(url);
	///		string facebookshare = "http://www.facebook.com/sharer.php?s=100&p[title]=TITLE&p[url]=http://looneybits.com&p[summary]=yoursummaryhere&p[images][0]=http://looneybits.com/assets/img/p04.png";
	/// </summary>
	protected override void action()
	{
		
		int score=PlayerPrefs.GetInt (variableName);
		this.description = description + score;
		switch(this.transform.tag)
		{
		case "facebook":
			string facebookshare="http://www.facebook.com/dialog/feed?app_id="+FBAppID+"&link=http://looneybits.com&picture=http://looneybits.com/assets/img/p07.png&name="+System.Uri.EscapeDataString(title)+"&caption="+System.Uri.EscapeUriString(caption)+"&description="+System.Uri.EscapeDataString (description)+"&redirect_uri="+FBRedirectUri;
			Application.OpenURL(facebookshare);
			break;
		case "twitter":
		default:
			string twittershare = "http://twitter.com/home?status="+System.Uri.EscapeDataString(hashtags)+System.Uri.EscapeUriString (description);
			Application.OpenURL(twittershare);
			break;
			
		}
	}
}
}