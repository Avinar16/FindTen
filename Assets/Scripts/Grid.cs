using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid: MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private float grid_cells_distance = 0.75f;

    private int[,] GridArray;

    [SerializeField]
    public List<List<GameObject>> ObjectsList = new List<List<GameObject>>();

    [SerializeField]
    GameObject Object;
    void Start()
    {
        GridArray = new int[width, height];
        //create grid
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            List<GameObject> object_line_list = new List<GameObject>();
            for ( int y = 0; y < GridArray.GetLength(1); y++)
            {
                GameObject Spawned_Obj = Instantiate(Object, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, 0) * grid_cells_distance, Quaternion.identity);
                object_line_list.Add(Spawned_Obj);
                Spawned_Obj.transform.SetParent(gameObject.transform);
                Spawned_Obj.name = $"Circle {x} {y}";
            }
            ObjectsList.Add(object_line_list);
        }
        gameObject.transform.position = new Vector3((transform.position.x - (width - 1) * grid_cells_distance) / 2, (transform.position.y - (height - 1) * grid_cells_distance) / 2, 0);
    }
}
