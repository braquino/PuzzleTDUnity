using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
	public Color TileColor { get; private set;}
	public string Type { get; set; }

	public Resource (Color tileColor, string nameType)
	{
		this.TileColor = tileColor;
		this.Type = nameType;
	}
}
