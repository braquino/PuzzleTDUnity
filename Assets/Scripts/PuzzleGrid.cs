using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleGrid : MonoBehaviour {

	// Constants declarations
	private const int _maxGridWidth = 10;
	private const int _maxGridHeight = 10;
	private const int _size = 25;

	// Fields declaration
    public Transform _tile;
    public List<Tile> _gridList = new List<Tile>();
    public Transform _selectorSprite;
    private Selector _selector;
	private List<Resource> _resources = new List<Resource>
	{
		new Resource(Color.gray, "Iron"), new Resource(Color.green, "Wood"), new Resource(Color.red, "Fire"), new Resource(Color.blue, "Magic")
	};
	private CheckMatch _check; 


	// Use this for initialization
	void Start () {
		
		_check = new CheckMatch (this);
		for (int i = 0; i < _maxGridWidth; i++)
        {
			for (int j = 0; j < _maxGridHeight; j++)
            {
				Resource resType = _resources[Random.Range (0, _resources.Count)];
				_gridList.Add(new Tile(i, j, _size, Instantiate(_tile, 
															new Vector3(_size + i * _size, _size + j * _size, 0), 
                                                        	Quaternion.identity, 
															this.transform), resType));

            }
        }
        _selector = new Selector(_size, _gridList[0], _selectorSprite);
	}
	
	// Update is called once per frame
	void Update () {

		MoveSelector ();
		// change the selector state
		if (Input.GetKeyDown (KeyCode.Space))
			_selector.SelectorState = !_selector.SelectorState;


		if (!_selector.SelectorState) {
			SendTop ();
			var sword = _check.CheckSword();
			var bow = _check.CheckBow();
			if (bow != "Nothing" || sword != "Nothing")
				print (bow + " - " + sword);
		}
		foreach (var tile in _gridList) {
			tile.Update ();
		}

	}

	void MoveSelector(){
		int init_XCord = _selector.XCord;
		int init_YCord = _selector.YCord;

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			if (_selector.YCord + 1 == _maxGridHeight)
				_selector.YCord = 0;
			else
				_selector.YCord += 1;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			if (_selector.YCord - 1 < 0)
				_selector.YCord = _maxGridHeight - 1;
			else
				_selector.YCord -= 1;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			if (_selector.XCord + 1 == _maxGridWidth)
				_selector.XCord = 0;
			else
				_selector.XCord += 1;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			if (_selector.XCord - 1 < 0)
				_selector.XCord = _maxGridWidth - 1;
			else
				_selector.XCord -= 1;
		}
		//print (_selector.XCord + " - " + _selector.YCord);
		_selector.CurrentTile = _gridList.First(tile => tile.XCord == _selector.XCord && tile.YCord == _selector.YCord);
		_selector.Update ();

		if (_selector.SelectorState)
			SwapTiles(init_XCord,init_YCord,_selector.XCord,_selector.YCord);
	}

	void SwapTiles(int initX, int initY, int x, int y){
		Tile origin = _gridList.First (tile => tile.XCord == initX && tile.YCord == initY);
		Tile destination = _gridList.First (tile => tile.XCord == x && tile.YCord == y);
		if (origin.StateMoving == false && destination.StateMoving == false) {
			Vector3 destFinalPos = origin.BaseTransform.position;
			Vector3 origFinalPos = destination.BaseTransform.position;
			origin.BaseTransform.position = destination.BaseTransform.position;
			destination.Destination = destFinalPos;
			origin.Destination = origFinalPos;
			origin.StateMoving = true;
			destination.StateMoving = true;
			origin.XCord = x;
			origin.YCord = y;
			destination.XCord = initX;
			destination.YCord = initY;
		}
	}

	void SendTop (){
		for (int i = 0; i < _maxGridWidth; i++) {
			for (int j = 0; j < _maxGridHeight; j++) {
				Tile origin = _gridList.First (tile => tile.XCord == i && tile.YCord == j);
				if (origin.ResourceType.Type == "Destroyed") {
					if (origin.YCord < 9) {
						SwapTiles (i, j, i, j + 1);
					}
					else {
						Resource resType = _resources[Random.Range (0, _resources.Count)];
						origin.ResourceType = resType;
						origin.Update ();
					}

					
				}
			}
		}
	}
		

}
