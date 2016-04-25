using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class powerup : MonoBehaviour {

	public GameObject power;
	public Text fifteenseconds;
	
	void OnCollisionEnter (Collision other)
	{
	

		power.SetActive (false);
		fifteenseconds.gameObject.SetActive (true);

		Invoke ("fifteenseconddisappear", 1.5f);

	

	}
	void fifteenseconddisappear()
	{
		fifteenseconds.gameObject.SetActive (false);
		GM1.Score = GM1.Score+50f;

	}


									}


