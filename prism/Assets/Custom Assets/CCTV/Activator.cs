using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
	
	public GameObject activateThis;

	void OnTriggerEnter(Collider other){
		activateThis.SetActive(true);
	}
}
