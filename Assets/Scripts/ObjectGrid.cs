using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ObjectGrid : MonoBehaviour
{
    [SerializeField]
    private float TwoRowRatio = 0.20f;
    [SerializeField]
    private float ThreeRowRatio = .12f;
    [SerializeField]
    private float FourRowRatio = 0.08f;
    [SerializeField]
    private float CubeRatio = 0.02f;

    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private float grid_cells_distance = 0.75f;

    [SerializeField]
    GameObject ObjectToSpawn;
    void Start()
    {
        List<List<Point>> ObjectsList = CreateGrid();

        // Centralize Grid offset
        gameObject.transform.position = new Vector3((transform.position.x - (width - 1) * grid_cells_distance) / 2, (transform.position.y - (height - 1) * grid_cells_distance) / 2, transform.position.z - 1);

        GeneratePointsValues(ObjectsList);
    }
    private void GeneratePointsValues(List<List<Point>> Points)
    {
        var rand = new System.Random();

        int TwoRowTotal = (int)math.ceil(width * height * TwoRowRatio);
        if (TwoRowTotal % 2 != 0)
        {
            TwoRowTotal++;
        }
        for (int i = TwoRowTotal; i > 0; i -= 2)
        {
            int height_cell = rand.Next(0, height - 2);
            int width_cell = rand.Next(0, width - 2);
            if (!Points[width_cell][height_cell].IsSet())
            {
                int value = rand.Next(1, 9);
                Points[width_cell][height_cell].SetValue(value);
                bool isHorizontal = rand.NextDouble() >= 0.5;
                if (isHorizontal)
                {
                    Points[width_cell][height_cell + 1].SetValue(10 - value);
                }
                else
                {
                    Points[width_cell + 1][height_cell].SetValue(10 - value);
                }
            }
        }
        int ThreeRowTotal = (int)math.ceil(width * height * ThreeRowRatio);
        if (ThreeRowTotal % 2 != 0)
        {
            ThreeRowTotal++;
        }
        for (int i = ThreeRowTotal; i > 0; i -= 3)
        {
            int height_cell = rand.Next(0, height - 3);
            int width_cell = rand.Next(0, width - 3);
            if (!Points[width_cell][height_cell].IsSet())
            {
                int value = rand.Next(1, 3);
                int value2 = rand.Next(1, 3);
                Points[width_cell][height_cell].SetValue(value);
                bool isHorizontal = rand.NextDouble() >= 0.5;
                if (isHorizontal)
                {
                    Points[width_cell][height_cell + 1].SetValue(value2);
                    Points[width_cell][height_cell + 2].SetValue(10 - (value + value2));
                }
                else
                {
                    Points[width_cell + 1][height_cell].SetValue(value2);
                    Points[width_cell + 2][height_cell].SetValue(10 - (value + value2));
                }
            }
        }
        int FourRowTotal = (int)math.ceil(width * height * FourRowRatio);
        if (FourRowTotal % 2 != 0)
        {
            FourRowTotal++;
        }
        for (int i = FourRowTotal; i > 0; i -= 3)
        {
            int height_cell = rand.Next(0, height - 4);
            int width_cell = rand.Next(0, width - 4);
            if (!Points[width_cell][height_cell].IsSet())
            {
                int value = rand.Next(1, 3);
                int value2 = rand.Next(1, 3);
                int value3 = rand.Next(1, 3);
                Points[width_cell][height_cell].SetValue(value);
                bool isHorizontal = rand.NextDouble() >= 0.5;
                if (isHorizontal)
                {
                    Points[width_cell][height_cell + 1].SetValue(value2);
                    Points[width_cell][height_cell + 2].SetValue(value3);
                    Points[width_cell][height_cell + 3].SetValue(10 - value - value2 - value3);
                }
                else
                {
                    Points[width_cell + 1][height_cell].SetValue(value2);
                    Points[width_cell + 2][height_cell].SetValue(value3);
                    Points[width_cell + 3][height_cell].SetValue(10 - value - value2 - value3);
                }
            }
        }
        int CubeRowTotal = (int)math.ceil(width * height * CubeRatio);
        if (CubeRowTotal % 2 != 0)
        {
            CubeRowTotal++;
        }
        for (int i = CubeRowTotal; i > 0; i -= 3)
        {
            int height_cell = rand.Next(0, height - 2);
            int width_cell = rand.Next(0, width - 2);
            if (!Points[width_cell][height_cell].IsSet())
            {
                int value = rand.Next(1, 3);
                int value2 = rand.Next(1, 3);
                int value3 = rand.Next(1, 3);
                Points[width_cell][height_cell].SetValue(value);
                Points[width_cell][height_cell + 1].SetValue(value2);
                Points[width_cell+1][height_cell].SetValue(value3);
                Points[width_cell+1][height_cell+1].SetValue(10 - value - value2 - value3);

            }
        }
        foreach(List<Point> row in Points)
        {
            foreach(Point p in row)
            {
                if (!p.IsSet()) {
                    p.SetValue(rand.Next(1, 9));
                }
            }
        }
    }
    private List<List<Point>> CreateGrid()
    {
        List<List<Point>> PointList = new();
        int[,] GridArray = new int[width, height];
        //create grid
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            List<Point> point_line_list = new List<Point>();
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                GameObject Spawned_Obj = Instantiate(ObjectToSpawn, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0) * grid_cells_distance, Quaternion.identity);
                point_line_list.Add(Spawned_Obj.GetComponent<Point>());
                Spawned_Obj.transform.SetParent(gameObject.transform);
                Spawned_Obj.name = $"Circle {x} {y}";
            }
            PointList.Add(point_line_list);
        }
        return PointList;
    }
}
