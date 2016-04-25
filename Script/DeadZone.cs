using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {



	public GameObject power;
	int i=18; 
	
	void Update()
	{
		if (GM1.instance.startbuttonactive == false) {
			Invoke ("poweractive", i);
			i = i + 20;
		}
	}
	
	void poweractive()
	{
		power.SetActive (true);
		Invoke ("powerdisappear", 10);
	}
	
	void powerdisappear()
	{
		power.SetActive (false);
	}
	


	void OnTriggerEnter (Collider col)	//as the water is not rigid body it is a trigger
	{
		GM1.instance.LoseLife ();
	}

}