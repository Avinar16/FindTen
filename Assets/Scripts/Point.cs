using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    [SerializeField]
    private int value = 1;
    private TextMeshPro text;
    private void Awake()
    {
        text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        text.SetText(value.ToString());
    }
    public void SetValue(int value)
    {
        this.value = value;
        text.SetText(value.ToString());
    }
    public int GetValue()
    {
        return value;
    }
}
