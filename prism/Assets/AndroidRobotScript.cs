﻿using UnityEngine;
using System.Collections;

public class AndroidRobotScript : MonoBehaviour {
	
	private Transform myTransform;
	private Transform target;
	public float minFollowRange = 5f;
	public float maxFollowRange = 30f;
	private float rotationSpeed = 10;
    public float movementSpeed = 2;
	private bool isAlive = true;
	
	public GameObject projectile;
	public float fireRate;
	public float nextFire;
	
	public AudioClip alertSound;
	public AudioClip gunSound;
	
	
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

	

	
	private void Awake() 
	{
    	myTransform = transform;
	}
	
	// Use this for initialization
	private void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
 
    	target = go.transform;
		
		fireRate = 1f;
		nextFire = -1.0f;
		audio.PlayOneShot(alertSound);
 
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
		
		
		Debug.DrawLine(target.position, myTransform.position);
		
		float distance = Vector3.Distance(transform.position, target.position);
		
		if(distance < maxFollowRange && distance > minFollowRange)
		{
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
      		//transform.LookAt(target);
      		transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		
		if (distance < maxFollowRange) {
			
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Vector3 pos = myTransform.position;
				pos.y += 1.5f;
				var clone = Instantiate(projectile, pos, myTransform.rotation);
				audio.PlayOneShot(gunSound);
				
			}
		}
		
		// LASER ATTACK HERE
		
	}
	
	public void TakeDamage()
	{
		IsAlive = false;
	}
	
	public void FireGun()
	{
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				var clone = Instantiate(projectile, myTransform.position, myTransform.rotation);
			}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
		}
	}
	
	
}
