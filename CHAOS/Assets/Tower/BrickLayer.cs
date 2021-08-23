using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Brick { basic, cracked, weathered, broken };

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

public class BrickLayer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int bricksPerRow = 12;
    [SerializeField] private int initNumRows = 10;
    [SerializeField] private float distBetweenBricks = 2.0f;
    [SerializeField] private float distBetweenRows = 0.5f;

    [Header("Prefabs")]
    [SerializeField] private GameObject prefBrickBasic = null;

    Row row = new Row();
    List<Row> tower = new List<Row>();

    private void Start()
    {
        Initialise();
    }

    private void Update()
    {
        CheckNewRow();
    }

    private void Initialise()
    {
        for (int j = 0; j < initNumRows; j++)
        {
            row = new Row();

            for (int i = 0; i < bricksPerRow; i++)
            {
                row.AddBrick(Brick.basic);
            }

            tower.Add(row);

            //UpdateDisplay();
        }

        for (int j = 0; j < initNumRows; j++)
        {
            for (int i = 0; i < bricksPerRow; i++)
            {
                switch (tower[j].GetBrickAtIndex(i))
                {
                    case Brick.basic:
                        GameObject go = Instantiate(prefBrickBasic, this.transform);
                        Vector3 newPos = transform.position;
                        newPos.x += distBetweenBricks * i;

                        if (j % 2 == 0)
                            newPos.x += distBetweenBricks / 2;

                        newPos.y += distBetweenRows * j;
                        go.transform.position = newPos;
                        break;
                }
            }
        }
    }

    private void CheckNewRow()
    { 
        //if yes, tower.add(row), updatedisplay();
    }

    private void UpdateDisplay()
    { 
        //Instantiate bricks
    }
}
