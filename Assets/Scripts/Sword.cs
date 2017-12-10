using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	private Animator _animator;
	private Vector3 _destination;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();

		_destination = new Vector3 (600, 400, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position != _destination) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, new Vector3 (600, 400, 0), 1f);
			_animator.SetBool ("WalkingUp", true);
		}
		else
			_animator.SetBool ("WalkingUp", false);
	}
}
