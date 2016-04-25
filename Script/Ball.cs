using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float ballInitialVelocity = 20000f;
	public float ballIncreasingVelocity = 1000f;
	public Rigidbody rb;
	private bool ballInPlay;
	public GameObject deathParticles;
	int l=0;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate()
	{

		if(ballInPlay==false && GM1.instance.startbuttonactive==false)
		{
			GM1.instance.Scorerun=true;
			transform.parent=null;	//as ball is child of paddle,so ball movement is dependent on paddle,so as we want to free it,hence we make it free from being a child of paddle
			ballInPlay=true;	//ball in play becomes true now so this force below will never work again after one time,if it works then after right click the force will keep on increasing
			rb.isKinematic=false;	//now the physics will react to the ball,so the forces below will react to it.
			//rb.velocity = new Vector3(Mathf.Lerp(0f,MaxSpeed, Time.deltaTime),Mathf.Lerp(0f,MaxSpeed, Time.deltaTime),0f);//force will be added,so that ball moves in x-y(600,600) plane above
			rb.AddForce(ballInitialVelocity, ballInitialVelocity,0f);

		}
		//rb.velocity = new Vector3(Mathf.Lerp(0f,MaxSpeed, Time.deltaTime),Mathf.Lerp(0f,MaxSpeed, Time.deltaTime),0f);
	


	}
//	void ballspeedconstant()
//	{
//		ballIncreasingVelocity = 0;
//	}


//
	void OnCollisionEnter (Collision other)
	{
		Instantiate (deathParticles, transform.position, Quaternion.identity);
		if (other.gameObject.CompareTag ("Finish") && l<=8) {
			l++;
			rb.AddForce (new Vector3 (ballIncreasingVelocity, ballIncreasingVelocity, 0f));
			Debug.Log(l);
													}
	}

	

}








