using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class googleserviceintegration : MonoBehaviour {

	public Button login;
	public Button logout;
	public string leaderboard;
	//	public static int x=0;
		
		void Awake()
		{
			PlayGamesPlatform.DebugLogEnabled = true;
			PlayGamesPlatform.Activate ();
		}
		
	   public void onclickingmegooglelogin()
		{
	

			Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					Debug.Log ("Login Sucess");
				} else {
					Debug.Log ("Login failed");
				}
			});
		login.gameObject.SetActive (false);
		logout.gameObject.SetActive (true);
		}
		



		public void OnAddScoreToLeaderBorad()
		{
			int x=PlayerPrefs.GetInt("highscore");
			if (Social.localUser.authenticated)
			{
			Social.ReportScore(x,leaderboard , (bool success) => 
				                   {
					if (success)
					{
					Social.ShowLeaderboardUI();
					}
					else
					{
					Debug.Log("Add Score Fail");
					}
				});
			}
		}



		public void OnLogOut()
		{
			((PlayGamesPlatform)Social.Active).SignOut();
		login.gameObject.SetActive (true);
		logout.gameObject.SetActive (false);
		}



}




																		