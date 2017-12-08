using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class default_tile : MonoBehaviour {

    private List<Color> _colors = new List<Color>
    {
        Color.red, Color.blue, Color.yellow, Color.green
    };

	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().color = _colors[Random.Range(0,_colors.Count)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
