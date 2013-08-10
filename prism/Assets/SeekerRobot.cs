﻿using UnityEngine;
using System.Collections;

public class SeekerRobot : MonoBehaviour 
{

	
    private Transform myTransform;
	private Transform target;
	private float minFollowRange = 2f;
	private float maxFollowRange = 100f;
    private bool follow = false;
	private float rotationSpeed = 10;
	private float movementSpeed = 2;
	private bool isAlive = true;
	
	/// <summary>
	/// Gets/Sets the IsAlive Property. Can set, but it is advised to call TakeDamage()
	/// </summary>
	/// <value>
	/// <c>true</c> if this AI is alive; otherwise, <c>false</c>.
	/// </value>
	public bool IsAlive {
		get
		{
			return isAlive;
		}
		set
		{
			if (value != isAlive) 
			{
				isAlive = value;
			}
		}
	}
	
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
	
	public void TakeDamage()
	{
		IsAlive = false;
	}
}
