using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile{
    public int XCord { get; set; }
    public int YCord { get; set; }
    public Transform BaseTransform { get; set; }

    public Tile(int xcord, int ycord, Transform basetransform)
    {
        this.XCord = xcord;
        this.YCord = ycord;
        this.BaseTransform = basetransform;
    }
}
public class Selector
{
    public int XCord { get; set; }
    public int YCord { get; set; }
    public Tile CurrentTile { get; set; }
    public Transform SelectorSprite { get; set; }

    public Selector(Tile currentTile, Transform sprite)
    {
        this.CurrentTile = currentTile;
        this.SelectorSprite = sprite;
        this.XCord = CurrentTile.XCord;
        this.YCord = CurrentTile.YCord;
        SelectorSprite.position = CurrentTile.BaseTransform.position;
    }

}
