using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public static Main_Menu instance; // ����������� ���������� ��� �������� ������ �� ���������
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            // ���� instance ����� null, ����������� ��� � ���������� ������� ������
            instance = this;
        }
        else if (instance != this)
        {
            // ���� ��� ���������� ������ ���������, ���������� ������� ������ (��������)
            Destroy(gameObject);
        }
    }
}
