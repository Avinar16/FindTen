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
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.2f); // Загрузите сохраненное значение громкости или 0.5 по умолчанию
        volumeSlider.onValueChanged.AddListener(SetVolume); // Добавляем слушателя на изменение значения слайдера
    }

    private void SetVolume(float volume)
    {
        if (Main_Menu_Sound.instance != null && Main_Menu_Sound.instance.audioSource != null)
        {
            Main_Menu_Sound.instance.audioSource.volume = volume;
        }
        PlayerPrefs.SetFloat("volume", volume); // Сохраняем значение громкости
    }
}
