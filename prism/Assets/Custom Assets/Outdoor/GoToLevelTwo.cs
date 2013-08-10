using UnityEngine;
using System.Collections;

public class GoToLevelTwo : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Application.LoadLevel("finalLevel2");
	}
}
