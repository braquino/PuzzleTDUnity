using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatch
{
	public List<Tile> grid { get; set; }

	public CheckMatch (PuzzleGrid puzzleGrid)
	{
		grid = puzzleGrid._gridList;
	}

	public string CheckSword()
	{
		int initX = 1;
		int endX = 9;
		int initY = 0;
		int endY = 5;

		for (int i = initX; i < endX; i++) {
			for (int j = initY; j < endY; j++) {
				List<Tile> checkedGrid = new List<Tile> ();
				checkedGrid.Add(GetTile (i + 0, j + 5));
				checkedGrid.Add (GetTile(i + 0, j + 4));
				checkedGrid.Add (GetTile(i + 0, j + 3));
				checkedGrid.Add (GetTile(i + 1, j + 2));
				checkedGrid.Add (GetTile(i + 0, j + 2));
				checkedGrid.Add (GetTile(i - 1, j + 2));
				checkedGrid.Add (GetTile(i + 0, j + 1));
				checkedGrid.Add (GetTile(i + 0, j + 0));

				if (checkedGrid[0].ResourceType.Type == "Iron" &&
					checkedGrid[1].ResourceType.Type == "Iron" &&
					checkedGrid[2].ResourceType.Type == "Iron" &&
					checkedGrid[3].ResourceType.Type == "Wood" &&
					checkedGrid[4].ResourceType.Type == "Wood" &&
					checkedGrid[5].ResourceType.Type == "Wood" &&
					checkedGrid[6].ResourceType.Type == "Wood" &&
					checkedGrid[7].ResourceType.Type == "Wood") {

					for(int z = 0; z < checkedGrid.Count; z++) {
						checkedGrid[z].ResourceType = new Resource(Color.black, "Destroyed");
						checkedGrid [z].Update ();
					}

					return "Sword";

				}
			}
		}

		return "Nothing";
	}

	private Tile GetTile(int x, int y)
	{
		return grid.First (tile => tile.XCord == x && tile.YCord == y);
	}
}
