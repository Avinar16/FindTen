using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrid : MonoBehaviour
{
    [SerializeField]
    private float TwoRowRatio = 0.20f;
    [SerializeField]
    private float ThreeRowRation = .12f;
    [SerializeField]
    private float FourRowRatio = 0.08f;
    [SerializeField]
    private float CubeRatio = 0.02f;
    private List<float> RowsRatio;

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
        List<List<GameObject>> ObjectsList = CreateGrid();

        // Centralize Grid offset
        gameObject.transform.position = new Vector3((transform.position.x - (width - 1) * grid_cells_distance) / 2, (transform.position.y - (height - 1) * grid_cells_distance) / 2, transform.position.z - 1);
    }
    private void Awake()
    {
        RowsRatio = new List<float>() {TwoRowRatio, ThreeRowRation, FourRowRatio, CubeRatio};
    }
    private void GeneratePointsValues(List<List<GameObject>>  ObjectsList)
    {

    }
    private List<List<GameObject>> CreateGrid()
    {
        List<List<GameObject>> ObjectsList = new();
        int[,] GridArray = new int[width, height];
        //create grid
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            List<GameObject> object_line_list = new List<GameObject>();
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                GameObject Spawned_Obj = Instantiate(ObjectToSpawn, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0) * grid_cells_distance, Quaternion.identity);
                object_line_list.Add(Spawned_Obj);
                Spawned_Obj.transform.SetParent(gameObject.transform);
                Spawned_Obj.name = $"Circle {x} {y}";
            }
            ObjectsList.Add(object_line_list);
        }
        return ObjectsList;
    }
}
