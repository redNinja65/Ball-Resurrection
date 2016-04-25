using UnityEngine;
using System.Collections;

public class loadingthegame : MonoBehaviour {

	// Use this for initialization
	public void onclickstartthegame () {
	
		float fadeTime = GameObject.Find ("fading").GetComponent<Fading> ().BeginFade (1);
		Invoke ("loadnextlevel", fadeTime);
	}
	
	void loadnextlevel()
	{
		Application.LoadLevel ("dxballandroid");
	}
}
