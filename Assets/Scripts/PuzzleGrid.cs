using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGrid : MonoBehaviour {

    public Transform _tile;
    private List<Tile> _gridList = new List<Tile>();
    public Transform _selectorSprite;
    private Selector _selector;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _gridList.Add(new Tile(i, j, Instantiate(_tile, 
                                                        new Vector3(50 + i * 50, 50 + j * 50, 0), 
                                                        Quaternion.identity, 
                                                        this.transform)));

            }
        }
        _selector = new Selector(_gridList[0], _selectorSprite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
