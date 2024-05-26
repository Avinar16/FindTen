using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.2f); // ��������� ����������� �������� ��������� ��� 0.5 �� ���������
        volumeSlider.onValueChanged.AddListener(SetVolume); // ��������� ��������� �� ��������� �������� ��������
    }

    private void SetVolume(float volume)
    {
        if (Main_Menu.instance != null && Main_Menu.instance.audioSource != null)
        {
            Main_Menu.instance.audioSource.volume = volume;
        }
        PlayerPrefs.SetFloat("volume", volume); // ��������� �������� ���������
    }
}
