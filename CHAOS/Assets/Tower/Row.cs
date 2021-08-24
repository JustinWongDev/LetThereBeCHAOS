using System.Collections.Generic;

public class Row
{
    List<Brick> row = new List<Brick>();

    public Row()
    {
        List<Brick> row = new List<Brick>();
    }

    public void AddBrick(Brick brick)
    {
        row.Add(brick);
    }

    public Brick GetBrickAtIndex(int index)
    {
        return row[index];
    }
}
