using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Sound : MonoBehaviour
{
    public static Main_Menu_Sound instance; // ����������� ���������� ��� �������� ������ �� ���������
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            // ���� instance ����� null, ����������� ��� � ���������� ������� ������
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ������� ������ ��� �������� ����� �����
        }
        else if (instance != this)
        {
            // ���� ��� ���������� ������ ���������, ���������� ������� ������ (��������)
            Destroy(gameObject);
        }
    }
}
