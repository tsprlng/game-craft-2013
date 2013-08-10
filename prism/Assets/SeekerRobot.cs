using UnityEngine;
using System.Collections;

public class SeekerRobot : MonoBehaviour 
{

	
    private Transform myTransform;
	private Transform target;
	private float minFollowRange = 2f;
	private float maxFollowRange = 100f;
    private bool follow = false;
	private bool isAlive = true;
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
		
		float distance = Vector3.Distance(myTransform.position,target.position);
		
		if(distance > minFollowRange)
		{
   			follow = true;
		}
		
		if(follow)
		{
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
   			//transform.LookAt(target);
   			myTransform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		
	}
}
