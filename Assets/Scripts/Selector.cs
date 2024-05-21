using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Transform SelectionArea;
    Vector3 Start_position = Vector3.zero;
    Vector3 End_position = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Select();
    }
    private void Select()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Start_position = ScreenToWorldCoordinates(touch.position);
                    Debug.Log(Start_position);
                    break;

                case TouchPhase.Moved:
                    End_position = ScreenToWorldCoordinates(touch.position);
                    SelectionArea.position = (Start_position + End_position) / 2;
                    SelectionArea.localScale = new Vector3(Mathf.Abs(End_position.x - Start_position.x), Mathf.Abs(End_position.y - Start_position.y), 0);
                    break;

                case TouchPhase.Ended:
                    CalculateArea(Start_position, End_position);
                    SelectionArea.localScale = Vector3.zero;
                    break;
            }
        }
    }
    Vector3 ScreenToWorldCoordinates(Vector3 touch_pos)
    {
        touch_pos.z = 10;
        return Camera.main.ScreenToWorldPoint(touch_pos);
    }
    private void CalculateArea(Vector3 Start, Vector3 End)
    {
        Collider2D[] found_objects = Physics2D.OverlapAreaAll(Start, End);
        List<Point> found_points = new List<Point>();
        int sum = 0;
        for(int i = 0; i < found_objects.Length; i++)
        {
            Point point = found_objects[i].gameObject.GetComponent<Point>();
            sum += point.GetValue();
        }
        if(sum == 10)
        {
            for(int i =0; i < found_objects.Length; i++)
            {
                Destroy(found_objects[i].gameObject);
                //add score;
            }
        }
    }
}
