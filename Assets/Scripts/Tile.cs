using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
    public int XCord { get; set; }
    public int YCord { get; set; }
    public Transform BaseTransform { get; set; }
	public Resource ResourceType { get; set; }
	public Vector3 Destination { get ; set; }
	public bool StateMoving { get ; set; }
	 

	public Tile(int xcord, int ycord, int size, Transform basetransform, Resource resource)
    {
        this.XCord = xcord;
        this.YCord = ycord;
        this.BaseTransform = basetransform;
		this.ResourceType = resource;
		this.Destination = BaseTransform.position;
		StateMoving = false;
		BaseTransform.GetComponent<SpriteRenderer> ().color = ResourceType.TileColor;
		BaseTransform.localScale = new Vector3 (size, size, 0);
    }

	public void Update()
	{
		BaseTransform.GetComponent<SpriteRenderer> ().color = ResourceType.TileColor;
		//print (BaseTransform.position != Destination);
		if (BaseTransform.position == Destination)
			StateMoving = false;
		if (BaseTransform.position != Destination){
			BaseTransform.position = Vector3.MoveTowards(BaseTransform.position, Destination, 5f);

		}
	}

}

