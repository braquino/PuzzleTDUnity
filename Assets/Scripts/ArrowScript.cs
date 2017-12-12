using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	public GameObject CurrentObjective;
	public int damage = 50;
	private Vector3 _destination;
	public string opponent;

	// Use this for initialization
	void Start () {
		_destination = CurrentObjective.transform.position;
		var angleBetween = Mathf.Atan2(_destination.y - transform.position.y, _destination.x - transform.position.x) * 180 / Mathf.PI;
		transform.localRotation = Quaternion.Euler(new Vector3 (0, 0, angleBetween -135));
	}


	
	// Update is called once per frame
	void Update () {

		if (this.transform.position != _destination) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, _destination, 2f);
		} else
			Destroy (gameObject);
		if (CurrentObjective == null)
			Destroy (gameObject);
	
	}
	void OnTriggerEnter2D (Collider2D other){
		var target = other.gameObject;
		if (target.tag == opponent) {
			target.GetComponent<Soldier> ().HP -= damage;
			Destroy (gameObject);
		}
	}
}
