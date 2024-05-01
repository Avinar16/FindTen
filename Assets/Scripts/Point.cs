using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    private int value;
    private TextMeshPro text;
    private void Awake()
    {
        text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
    }
    public void SetValue(int value)
    {
        this.value = value;
        text.SetText(value.ToString());
    }
}
