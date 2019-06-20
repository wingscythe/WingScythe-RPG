using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

	public GameObject monsters;
	public int count = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawn ());
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator spawn(){
		while (count<10) {
			GameObject creature = (GameObject)(Instantiate (monsters, this.transform.position, Quaternion.identity));
			count = count + 1;
			yield return new WaitForSeconds(3);
		}
	}
}
