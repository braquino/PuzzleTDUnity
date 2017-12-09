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
				checkedGrid.Add (GetTile(i + 0, j + 5));
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

					DestroyTiles (checkedGrid);
					return "Sword";

				}
			}
		}
		return "Nothing";
	}
	public string CheckBow()
	{
		int initX = 0;
		int endX = 8;
		int initY = 0;
		int endY = 7;

		for (int i = initX; i < endX; i++) {
			for (int j = initY; j < endY; j++) {
				List<Tile> checkedGrid = new List<Tile> ();
				checkedGrid.Add (GetTile(i + 1, j + 3));
				checkedGrid.Add (GetTile(i + 2, j + 2));
				checkedGrid.Add (GetTile(i + 2, j + 1));
				checkedGrid.Add (GetTile(i + 1, j + 0));
				checkedGrid.Add (GetTile(i + 0, j + 3));
				checkedGrid.Add (GetTile(i + 0, j + 2));
				checkedGrid.Add (GetTile(i + 0, j + 1));
				checkedGrid.Add (GetTile(i + 0, j + 0));

				if (checkedGrid[0].ResourceType.Type == "Wood" &&
					checkedGrid[1].ResourceType.Type == "Wood" &&
					checkedGrid[2].ResourceType.Type == "Wood" &&
					checkedGrid[3].ResourceType.Type == "Wood" &&
					checkedGrid[4].ResourceType.Type == "Iron" &&
					checkedGrid[5].ResourceType.Type == "Iron" &&
					checkedGrid[6].ResourceType.Type == "Iron" &&
					checkedGrid[7].ResourceType.Type == "Iron") {

					DestroyTiles (checkedGrid);
					return "Bow";
				}
			}
		}
		return "Nothing";
	}
	public string CheckMage()
	{
		int initX = 1;
		int endX = 9;
		int initY = 0;
		int endY = 5;

		for (int i = initX; i < endX; i++) {
			for (int j = initY; j < endY; j++) {
				List<Tile> checkedGrid = new List<Tile> ();
				checkedGrid.Add (GetTile(i + 1, j + 3));
				checkedGrid.Add (GetTile(i + 2, j + 2));
				checkedGrid.Add (GetTile(i + 2, j + 1));
				checkedGrid.Add (GetTile(i + 1, j + 0));
				checkedGrid.Add (GetTile(i + 0, j + 3));
				checkedGrid.Add (GetTile(i + 0, j + 2));
				checkedGrid.Add (GetTile(i - 1, j + 1));
				checkedGrid.Add (GetTile(i + 0, j + 0));

				if (checkedGrid[0].ResourceType.Type == "Wood" &&
					checkedGrid[1].ResourceType.Type == "Wood" &&
					checkedGrid[2].ResourceType.Type == "Wood" &&
					checkedGrid[3].ResourceType.Type == "Wood" &&
					checkedGrid[4].ResourceType.Type == "Iron" &&
					checkedGrid[5].ResourceType.Type == "Iron" &&
					checkedGrid[6].ResourceType.Type == "Iron" &&
					checkedGrid[7].ResourceType.Type == "Iron") {

					DestroyTiles (checkedGrid);
					return "Mage";
				}
			}
		}
		return "Nothing";
	}

	private Tile GetTile(int x, int y)
	{
		return grid.First (tile => tile.XCord == x && tile.YCord == y);
	}

	private void DestroyTiles(List<Tile> checkedGrid)
	{
		for (int z = 0; z < checkedGrid.Count; z++) {
			checkedGrid [z].ResourceType = new Resource (Color.black, "Destroyed");
			checkedGrid [z].Update ();
		}
	}
}
