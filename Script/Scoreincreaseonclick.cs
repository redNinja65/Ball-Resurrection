using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreincreaseonclick : MonoBehaviour {


	public Text left;
	public Text right;
	void Awake()
	{
		//info.fontSize = (int)(Screen.width * 0.06f);
		//left.fontSize = (int)(Screen.width * 0.06f);
		//right.fontSize = (int)(Screen.width * 0.06f);
	}
	void Update()
	{
		if (Input.GetButtonDown ("Fire1") && GM1.instance.isgameover==false && GM1.instance.startbuttonactive==false) //when the game is over then after clicking more the score will not increase this if condition is for that thing
		{
		
			GM1.Score++;

		}

	}
}
