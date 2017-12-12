using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Soldier: MonoBehaviour {

	private Animator _animator;
	private enum States {Idle, Walking, Attacking};
	private States _currentState = States.Idle;
	private Vector3 _objective;
	public string TypeObject = "Sword";
	public GameObject CurrentObjective;
	public int AttackRange = 50;
	public GameObject _arena;
	public int HP = 200;
	public int AP = 30;
	public GameObject _arrow;
	public string opponent = "Player2";

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		if (this.tag == "Player1")
			opponent = "Player2";
		else if (this.tag == "Player2")
			opponent = "Player1";


		//StartCoroutine (ChangeState());
	}

	// Update is called once per frame
	void Update () {
		TestDeath ();
		SetObjective ();
		_objective = CurrentObjective.transform.position;
		UpdateState ();
		MoveToObjective ();
	}
	void MoveToObjective (){
		//print (this.transform.position.y - _objective.y);
		if (Mathf.Abs (this.transform.position.y - _objective.y) >= AttackRange) {
			_currentState = States.Walking;
			this.transform.position = Vector3.MoveTowards (this.transform.position, _objective, 1f);
		} else if (Mathf.Abs(this.transform.position.y - _objective.y) < AttackRange) {
			_currentState = States.Idle;
			if (CurrentObjective.GetComponent<Soldier> ().TypeObject == "Sword")
				_currentState = States.Attacking;
		}
	}

	IEnumerator ChangeState(){
		yield return new WaitForSeconds (3);
		_currentState = States.Walking;

		yield return new WaitForSeconds (7);
		print ("Attacking");
		_currentState = States.Attacking;
	}

	void UpdateState(){
		//set the initial state up or down
		if (this.transform.position.y > _objective.y)
			_animator.SetBool ("GoDown", true);
		else if (this.transform.position.y < _objective.y)
			_animator.SetBool ("GoDown", false);

		// change states between Idle, Walking and Attakickg.
		if (_currentState == States.Idle) {
			_animator.SetBool ("WalkingUp", false);
			_animator.SetBool ("AttackingUp", false);
		} else if (_currentState == States.Walking) {
			_animator.SetBool ("WalkingUp", true);
			_animator.SetBool ("AttackingUp", false);
		} else if (_currentState == States.Attacking) {	
			_animator.SetBool ("AttackingUp", true);
			_animator.SetBool ("WalkingUp", false);
		}

	}

	void SetObjective(){
		

		List<GameObject> list = GameObject.FindGameObjectsWithTag (opponent).ToList();
		//print (list [0].transform.position.ToString ());
		CurrentObjective = list[0];
		for (int i = 1; i < list.Count; i++) {
			if((Vector3.Distance(this.transform.position, list[i].transform.position) < Vector3.Distance(this.transform.position, CurrentObjective.transform.position)) && list[i] != null)
				CurrentObjective = list[i];
		}

	}

	void CauseDamage (){
		if (CurrentObjective != null)
			CurrentObjective.GetComponent<Soldier>().HP -= AP;
	}

	void Shot (){
		GameObject arrow = Instantiate (_arrow, this.transform.position, Quaternion.identity, _arena.transform) as GameObject;
		arrow.GetComponent<ArrowScript> ().CurrentObjective = this.CurrentObjective;
		arrow.GetComponent<ArrowScript> ().damage = this.AP;
		arrow.GetComponent<ArrowScript> ().opponent = this.opponent;
	}

	void TestDeath(){
		if (HP < 0)
			Destroy (gameObject);
	}
}
