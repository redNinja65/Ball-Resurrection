using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class SimpleAds : MonoBehaviour 
{
	static int i=0;
	public Text advertisementloading;
	void Start()
	{
		i++;
	}
void Update () 
{
		Debug.Log (GM1.instance.isgameover);
		Debug.Log (i);
		if ((GM1.instance.isgameover == true) && (i >= 2)){

			advertisementloading.gameObject.SetActive (true);
			Invoke("textdisappear",2f);
			Invoke("showingadd",0.5f);
		}
	
}

void showingadd()
	{
		if ((GM1.instance.isgameover == true) && (i >= 2)) {
			
			Advertisement.Initialize ("1024948", false);

			
			
			StartCoroutine (ShowAdWhenReady ());
			GM1.instance.isgameover = false;	
			
		}

	}

IEnumerator ShowAdWhenReady()
{
	while (!Advertisement.isReady())
		yield return null;
	
	
	Advertisement.Show ();
}
	void textdisappear()
	{
		advertisementloading.gameObject.SetActive (false);
	}

}