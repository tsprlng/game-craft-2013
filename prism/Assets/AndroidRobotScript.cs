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
	private bool isAlive = true;
	
	public float bulletSpeed;
	public GameObject projectile;
	public float fireRate;
	public float nextFire;
	
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
		
		bulletSpeed = 15f;
		fireRate = 1f;
		nextFire = -1.0f;
		
 
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
				var clone = Instantiate(projectile, myTransform.position, myTransform.rotation);
				
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

	
	
	
}
