using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PostScore : MonoBehaviour {

	private int score;
	void Start()
	{
		score = PlayerPrefs.GetInt ("Score", 0);	//this "Score"is the name of the leaderboard name,when u will create it make it Score only (and ,0) is showing initially leaderboard will have 0 score of urs,it's called a key actually
	}





	public void OnClickings () 
	{
		Social.ReportScore (score, "LEADERBOARD ID", (bool success) =>
		{
			if (success)
			{
				Debug.Log("You've successfully Posted the score");
			}
			else
			{
				Debug.Log("Score was not uploaded due to some reason");
			}						
		});
		
	}
}
