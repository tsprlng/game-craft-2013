using UnityEngine;
using System.Collections;

public class AndroidRobotScript : MonoBehaviour {
	
	private Transform myTransform;
	private Transform target;
	private float minFollowRange = 5f;
	private float maxFollowRange = 100f;
	private float attackRange = 3;
	private float attackDelay = 1;
	private float rotationSpeed = 10;
    private float movementSpeed = 2;

	

	
	void Awake() 
	{
    	myTransform = transform;
	}
	
	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
 
    	target = go.transform;
 
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.DrawLine(target.position, myTransform.position);
		
		float distance = Vector3.Distance(transform.position, target.position);
		
		if(distance < maxFollowRange && distance > minFollowRange)
		{
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
      		//transform.LookAt(target);
      		transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		
		// LASER ATTACK HERE
		
	}
}
