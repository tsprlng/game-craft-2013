using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
		
	
	public float bulletSpeed;
	public string bulletOwner;
	private Transform target;
	public bool hasHitTarget;
	private GameObject go = new GameObject();
	private GameObject[] go2;
	
	// Use this for initialization
	void Start () 
	{
		bulletSpeed = 15f;
		
		if (bulletOwner == "Player") {
			
			go2 = GameObject.FindGameObjectsWithTag("AI");
		}
		else
		{
			go = GameObject.FindGameObjectWithTag("Player");
			target = go.transform;
		}


		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		float distance; // = Vector3.Distance(transform.position, target.position);
		
			
		if (!renderer.isVisible) 
		{
			Destroy(gameObject);
			return;
		}
		
		
		if (bulletOwner == "Player") 
		{
			
			foreach (GameObject item in go2) 
			{
				distance = Vector3.Distance(transform.position, item.transform.position);
				
				if (distance < 1) {
					Destroy(item);
				}
				
			}	
			
		}
		else
		{
			distance = Vector3.Distance(transform.position, target.position);
			if (distance <= 1) {
				Destroy(gameObject);
				hasHitTarget = true;
				
				if (bulletOwner == "AI") {
					Application.LoadLevel(Application.loadedLevel);
				}
				
				Debug.Log("Hit Target");
			}
			
		}
		
		
		
		
		transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
		

	}
	
	

	
}
