using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    [SerializeField]
    private int value = 1;
    private bool isSet = false;
    private TextMeshPro text;
    private void Awake()
    {
        text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        text.SetText(value.ToString());
    }
    public void SetValue(int value)
    {
        this.value = value;
        isSet = true;
        text.SetText(value.ToString());
    }
    public int GetValue()
    {
        return value;
    }
    public bool IsSet() { 
        return isSet;
    }
}
