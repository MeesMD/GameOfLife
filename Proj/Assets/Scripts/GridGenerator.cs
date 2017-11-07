using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public static int gridWidth = 30;
    public static int gridHeight = 30;
    int aliveNeighbours = 0;
    public GameObject tile;
    public GameObject[,] grid;
    public bool doChange = false;
    public static bool[,] arraydab = new bool[gridWidth, gridHeight];
    public static bool[,] arrayyeet = new bool[gridWidth, gridHeight];
    bool isLiving;
    private SpriteRenderer spr;



    // Use this for initialization
    void Start()
    {
        grid = new GameObject[gridWidth, gridHeight];

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject gridCell = Instantiate(tile);

                gridCell.transform.position = new Vector3(tile.transform.position.x + i, 
                tile.transform.position.y, gridCell.transform.position.z + j);

                grid[i, j] = gridCell;
                arraydab[i, j] = false;
                arrayyeet[i, j] = false;

            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Iterate();
            
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    spr = grid[i, j].GetComponent<SpriteRenderer>();
                    if (arrayyeet[i, j])
                    {
                        spr.sprite = GetComponent<ColorChanger>().sprite2;
                    }
                    else
                    {
                        spr.sprite = GetComponent<ColorChanger>().sprite1;
                    }
                }
            }
            
        }
    }

    void LEUK()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                arraydab[i, j] = arrayyeet[i, j];
            }
        }
    }


    void Iterate()
    {
        print("Yeet");
        LEUK();

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                
                isLiving = arraydab[i, j];
                int nrOfNeighbours = GetAliveNeighbourCount(i, j);

                if (isLiving && nrOfNeighbours < 2)
                    doChange = false;
                else if (isLiving && (nrOfNeighbours == 2 || nrOfNeighbours == 3))
                    doChange = true;
                else if (isLiving && nrOfNeighbours > 3)
                    doChange = false;
                else if (!isLiving && nrOfNeighbours == 3)
                    doChange = true;
                else
                    doChange = false;

                /*if(arraydab[i,j] == true)
                 {
                     if (aliveNeighbours == 2 || aliveNeighbours == 3)
                     {
                         arraydab[i, j] = true;
                         doChange = true;
                     }
                 }
                 else
                 {
                     arraydab[i, j] = false;
                     doChange = false;
                 }*/
                // logica v/h algoritme
                // welke tiles moeten veranderen? --> opslaan
            }
        }
        if(doChange == true)
        {
            GetComponent<ColorChanger>().ChangeSprite();
        }
        // uitvoeren v/d veranderingen
        // veranderingen uitvoeren dmv ChangeColor();
    }

    int GetAliveNeighbourCount(int x, int y)
    {
        if (x != gridWidth - 1)
            if (arraydab[x + 1, y])
                aliveNeighbours++;

        // Check cell on the bottom right.
        if (x != gridWidth - 1 && y != gridHeight - 1)
            if (arraydab[x + 1, y + 1])
                aliveNeighbours++;

        // Check cell on the bottom.
        if (y != gridHeight - 1)
            if (arraydab[x, y + 1])
                aliveNeighbours++;

        // Check cell on the bottom left.
        if (x != 0 && y != gridHeight - 1)
            if (arraydab[x - 1, y + 1])
                aliveNeighbours++;

        // Check cell on the left.
        if (x != 0)
            if (arraydab[x - 1, y])
                aliveNeighbours++;

        // Check cell on the top left.
        if (x != 0 && y != 0)
            if (arraydab[x - 1, y - 1])
                aliveNeighbours++;

        // Check cell on the top.
        if (y != 0)
            if (arraydab[x, y - 1])
                aliveNeighbours++;

        // Check cell on the top right.
        if (x != gridWidth - 1 && y != 0)
            if (arraydab[x + 1, y - 1])
                aliveNeighbours++;

        return aliveNeighbours;
    }
}