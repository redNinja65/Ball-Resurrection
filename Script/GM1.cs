using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM1 : MonoBehaviour {

	public static float Score=0f;
	AudioSource playerdiesound;
	public Button gamestart;
	public Button pausebuttonappears;
	public Text highscore;
	public Button highscorebutton;
	public Button leaderboard;
	public Button restart;		//public transform restart,will also works perfectly but we have to get the components in it while writing,as it is all about getting the gameobject through drag and drop in the scene
	public float resetDelay = 1f;
	public Text ScoreText;
	public bool Scorerun;
	public bool startbuttonactive=true;
	public bool isgameover=false;
	public GameObject paddle;	//instantiate a new paddle, player has lost a life when..
	public GameObject deathParticles;
	public static GM1 instance = null;	//by creating this,we make other scripts handle this scripts through,GM.instance.bricks=25; like this they can all alter this
	
	private GameObject clonePaddle;



	void Awake () 
	{

		if (instance == null)	//checking that we have a game manager or not,if null then instance(GM) here,become this..that is now it is,
			instance = this;
		else if (instance != this)//if there is any other game manager then destroy that game manager,gameobject
			Destroy (gameObject);
		
		Setup();
		//ScoreText.fontSize = (int)(Screen.width * 0.1f);
	}

	void Update()
	{

		if ((Scorerun == true))
		{
			Score += (Time.deltaTime);
			ScoreText.text = Score.ToString ("f0");	//it just show the first word of the string i.e (f0)
		}
		playerdiesound = GetComponent <AudioSource> ();

	}
	
	public void Setup()	
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;	//making paddle like game object at transform.position i.e. at gamemanager position which is(0,0,0) and no rotation by .identity
	}
	
	void GameOver()
	{
			Scorerun = false;
			isgameover = true;
			
			

			restart.gameObject.SetActive(true);	//gameobject has the setactive method,not a button,so either we select a gameobject and put the button inside it,then we can directly run it by.set active ,but here as it is button,so we first create it as a gameobject then,it property is applied..
			restart.interactable = true;//buttons,all component we have to get first,then only we can change its methods(which are present in the button),if the gameobject is transform then,else if Button is used abouve no need to write getcomponent and all


			leaderboard.gameObject.SetActive(true);
			leaderboard.interactable = true;


			int oldHighscore  = PlayerPrefs.GetInt("highscore", 0)   ;    
			if ((int) Score > oldHighscore) 
			{
				PlayerPrefs.SetInt ("highscore", (int) Score)  ;
				ScoreText.gameObject.SetActive(false);
			}
			highscorebutton.gameObject.SetActive (true);
			highscore.gameObject.SetActive (true);
			highscore.text = "Best: " + PlayerPrefs.GetInt("highscore");
	}
		

	public void RestartButton()
	{

		Score = 0;
		Application.LoadLevel("main");//restart the same level which was u were playing
		Invoke ("SetupPaddle", resetDelay);
	}
		

	
	public void LoseLife()
	{
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);//losing a life,particles will come and then paddle destroyed
		Destroy(clonePaddle);
		playerdiesound.Play ();
		GameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;	//creating a new paddle after destroying it,when life is lost
	}
	public void StartingButtonControl()
	{
		gamestart.gameObject.SetActive (false);
		gamestart.interactable = false;
		startbuttonactive = false;
		pausebuttonappears.gameObject.SetActive (true);

	}
	
	public void onclickingtheexit()
	{
		
		Application.Quit ();
	}
	


	

}