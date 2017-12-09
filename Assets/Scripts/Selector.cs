using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector
{
	public int XCord { get; set; }
	public int YCord { get; set; }
	public Tile CurrentTile { get; set; }
	public Transform SelectorSprite { get; set; }
	public bool SelectorState { get; set; }

	public Selector(int size, Tile currentTile, Transform sprite)
	{
		this.CurrentTile = currentTile;
		this.SelectorSprite = sprite;
		this.XCord = CurrentTile.XCord;
		this.YCord = CurrentTile.YCord;
		SelectorSprite.position = CurrentTile.BaseTransform.position;
		SelectorState = false;
		SelectorSprite.localScale = new Vector3 (size * 1.1f, size * 1.1f, 0f);
	}

	public void Update(){
		SelectorSprite.position = CurrentTile.BaseTransform.position;
		if (SelectorState)
			SelectorSprite.GetComponent<SpriteRenderer> ().color = Color.red;
		else
			SelectorSprite.GetComponent<SpriteRenderer> ().color = Color.white;
	}
}